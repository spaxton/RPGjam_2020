using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, FISHTURN, WON, LOST }

public class scr_fishing_combat : MonoBehaviour
{
    public GameObject[] fishPrefabs;
    public Transform fishStage;

    scr_fish fishUnit;

    public Text mainText;

    public scr_UI_manager UIman;

    public BattleState state;

    public GameObject loader_prefab;

    public Animator fish_motion;
    public Animator player_motion;


    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        var fishIndex = Random.Range(0, fishPrefabs.Length);

        GameObject fishGO = Instantiate(fishPrefabs[fishIndex], fishStage);
        fishUnit = fishGO.GetComponent<scr_fish>();
        fishUnit.dist = fishUnit.dist + Random.Range(-20,10);
        fish_motion = fishGO.GetComponent<Animator>();

        mainText.text = "An unidentified fish is on the line...";
        //Debug.Log("Fish: " + fishUnit.fishName);

        UIman.updateUI(fishUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator ReelHard()
    {
        fishUnit.GetReeled();
        UIman.updateUI(fishUnit);
        fish_motion.SetTrigger("reel");
        player_motion.SetTrigger("reel");
        mainText.text = "You reel with all your might!";

        yield return new WaitForSeconds(2f);

        if (CheckEnd())
        {
            EndBattle();
        } else
        {
            state = BattleState.FISHTURN;
            StartCoroutine(FishTurn());
        }
        
    }

    IEnumerator LetOut()
    {
        fishUnit.LetOut();
        UIman.updateUI(fishUnit);
        fish_motion.SetTrigger("let");
        player_motion.SetTrigger("let");
        mainText.text = "You release some tension from the line.";

        yield return new WaitForSeconds(2f);

        if (CheckEnd())
        {
            EndBattle();
        }
        else
        {
            state = BattleState.FISHTURN;
            StartCoroutine(FishTurn());
        }

    }

    IEnumerator GotBroke()
    {
        mainText.text = "The fishing line snapped!";

        yield return new WaitForSeconds(2f);

        fish_motion.SetTrigger("gotaway");
        mainText.text = "The fish got away...";

        yield return new WaitForSeconds(2f);

        loader_prefab.GetComponent<scr_level_loader>().LoadLevel(0, 1);

    }

    IEnumerator GotFree()
    {
        mainText.text = "The fish unhooked itself!";

        yield return new WaitForSeconds(2f);

        fish_motion.SetTrigger("gotaway");
        mainText.text = "The fish got away...";

        yield return new WaitForSeconds(2f);

        loader_prefab.GetComponent<scr_level_loader>().LoadLevel(0, 1);
    }

    IEnumerator Release()
    {
        player_motion.SetTrigger("unhook");
        fish_motion.SetTrigger("gotaway");
        mainText.text = "You let the fish return to the ocean.";

        yield return new WaitForSeconds(2f);

        loader_prefab.GetComponent<scr_level_loader>().LoadLevel(0, 1);
    }

    IEnumerator FishReveal()
    {
        yield return new WaitForSeconds(2f);

        UIman.revealFish(fishUnit);
        fishUnit.darkened.sprite = fishUnit.shown;
        fishUnit.FishCaught();

        mainText.text = "You caught a " + fishUnit.fishName + "!";

        yield return new WaitForSeconds(4f);

        loader_prefab.GetComponent<scr_level_loader>().LoadLevel(0, 1);

    }

    IEnumerator FishTurn()
    {
        // pick a random action
        // if so, do the thing

        var fishAct = Random.Range(0, 2);

        if(fishAct == 0)
        {
            bool fishSwam = fishUnit.SwimAway();

            if (fishSwam)
            {
                fish_motion.SetTrigger("swim");
                mainText.text = "The fish struggles against the line.";
            }
            else
            {
                fish_motion.SetTrigger("rest");
                mainText.text = "The fish recovers its energy.";
            }
            UIman.updateUI(fishUnit);
        }

        if(fishAct == 1)
        {
            bool fishDove = fishUnit.DiveDeep();

            if (fishDove)
            {
                fish_motion.SetTrigger("dive");
                mainText.text = "The fish dives away from the boat.";
            }
            else
            {
                fish_motion.SetTrigger("rest");
                mainText.text = "The fish recovers its energy.";
            }
            UIman.updateUI(fishUnit);
        }

        if(fishAct == 2)
        {
            bool fishJuke = fishUnit.JukeSide();

            if (fishJuke)
            {
                fish_motion.SetTrigger("juke");
                mainText.text = "The fish flaisl wildly!";
            }
            else
            {
                fish_motion.SetTrigger("rest");
                mainText.text = "The fish recovers its energy.";
            }
            UIman.updateUI(fishUnit);
        }

        

        yield return new WaitForSeconds(2f);

        bool caught = fishUnit.caught;
        bool escaped = fishUnit.escaped;

        if (caught == true)
        {
            state = BattleState.WON;
            EndBattle();
        }

        if (escaped == true)
        {
            state = BattleState.LOST;
            EndBattle();
        }

        if (caught == false && escaped == false)
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    bool CheckEnd()
    {
        bool caught = fishUnit.caught;
        bool escaped = fishUnit.escaped;

        if (caught == true)
        {
            state = BattleState.WON;
            return true;
        }

        if (escaped == true)
        {
            state = BattleState.LOST;
            return true;
        }

        return false;
    }

    void EndBattle()
    {
        bool broke = fishUnit.broke;
        bool freed = fishUnit.freed;

        if (state == BattleState.WON)
        {
            mainText.text = "You caught the fish! What was it?";

            StartCoroutine(FishReveal());

        } else if (state == BattleState.LOST)
        {
            if (broke)
            {
                StartCoroutine(GotBroke());
            }
            if (freed)
            {
                StartCoroutine(GotFree());
            }
        }
    }

    void PlayerTurn()
    {
        mainText.text = "What will you do?";
    }

    public void ReelHardButt()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(ReelHard());
    }

    public void LetOutButt()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(LetOut());
    }

    public void ReleaseButt()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(Release());
    }
}
