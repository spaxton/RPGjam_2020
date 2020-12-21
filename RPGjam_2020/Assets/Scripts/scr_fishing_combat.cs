using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, FISHTURN, WON, LOST }

public class scr_fishing_combat : MonoBehaviour
{
    public GameObject fishPrefab;
    public Transform fishStage;

    scr_fish fishUnit;

    public Text mainText;

    public scr_UI_manager UIman;

    public BattleState state;


    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SetupBattle()
    {
        GameObject fishGO = Instantiate(fishPrefab, fishStage);
        fishUnit = fishGO.GetComponent<scr_fish>();
        fishUnit.dist = fishUnit.dist + Random.Range(-20,10);

        mainText.text = "An unidentified fish is on the line...";

        UIman.updateUI(fishUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator ReelHard()
    {
        fishUnit.GetReeled();
        UIman.updateUI(fishUnit);
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

        mainText.text = "The fish got away...";

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(0);

    }

    IEnumerator GotFree()
    {
        mainText.text = "The fish unhooked itself!";

        yield return new WaitForSeconds(2f);
        
        mainText.text = "The fish got away...";

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(0);
    }

    IEnumerator Release()
    {
        mainText.text = "You let the fish return to the ocean.";

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(0);
    }

    IEnumerator FishReveal()
    {
        yield return new WaitForSeconds(2f);

        UIman.revealFish(fishUnit);
        fishUnit.darkened.sprite = fishUnit.shown;

        mainText.text = "You caught a " + fishUnit.fishName + "!";

        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene(0);

    }

    IEnumerator FishTurn()
    {
        // pick a random action
        // check if there is enough energy
        // if not, rest
        // if so, do the thing

        bool fishSwam = fishUnit.SwimAway();

        if (fishSwam)
        {
            mainText.text = "The fish struggles against the line.";
        } else
        {
            mainText.text = "The fish recovers its energy.";
        }
        UIman.updateUI(fishUnit);

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