using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_player : MonoBehaviour
{

    public float moveSpeed = 2f;
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject fishtarget;
    public GameObject interTarget;

    public GameObject DeckUI;

    public enum States
    {
        Reading,
        Walking,
        Sitting,
        Fishing
    }
    public States player_state = States.Walking;
    States prev_state;

    public bool can_fish = false;
    public bool can_int = false;
    private bool casting = false;
    private bool fishing;
    public bool input;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // BASE state
        if (player_state == States.Walking)
        {
            // get input
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            // set animations
            animator.SetFloat("horizontal", movement.x);
            animator.SetFloat("vertical", movement.y);
            animator.SetFloat("speed", movement.sqrMagnitude);
            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {
                animator.SetFloat("last_x", Input.GetAxisRaw("Horizontal"));
                animator.SetFloat("last_y", Input.GetAxisRaw("Vertical"));
                input = true;
            } else
            {
                input = false;
            }

            // provide context
            if (fishtarget.GetComponent<scr_fishtarget>().can_fish == true && input == false || interTarget.GetComponent<scr_interTarget>().can_int == true && input == false)
            {
                // fishing context
                if (fishtarget.GetComponent<scr_fishtarget>().can_fish == true)
                {
                    can_fish = true;
                    can_int = false;
                    //Debug.Log("can fish");
                    if (DeckUI.GetComponent<scr_DeckUI>().ContextUp == false)
                    {
                        DeckUI.GetComponent<scr_DeckUI>().canfish_trigger();
                    }
                }

                // reading context
                if(interTarget.GetComponent<scr_interTarget>().can_int == true)
                {
                    can_int = true;
                    can_fish = false;
                    //Debug.Log("can't fish");
                    if (DeckUI.GetComponent<scr_DeckUI>().ContextUp == false)
                    {
                        DeckUI.GetComponent<scr_DeckUI>().canread_trigger();
                    }
                }
            } else
            {
                can_fish = false;
                can_int = false;
                //Debug.Log("can't fish");
                if (DeckUI.GetComponent<scr_DeckUI>().ContextUp == true)
                {
                    DeckUI.GetComponent<scr_DeckUI>().drop_context();
                }
            }

            // do things!

            if (Input.GetKeyDown(KeyCode.Space) && casting == false && can_fish == true)
            {
                player_state = States.Fishing;
                casting = true;
                fishing = true;
                animator.SetBool("fishing", true);
                StartCoroutine(cast_timer());
                StartCoroutine(fish_bite());
                DeckUI.GetComponent<scr_DeckUI>().canreel_trigger();
            }

            if (Input.GetKeyDown(KeyCode.Space) && interTarget.GetComponent<scr_interTarget>().can_int == true)
            {
                DeckUI.GetComponent<scr_DeckUI>().spawnNote();
            }

        }

        // GO fish

        if (player_state == States.Fishing)
        {
            if (Input.GetKeyDown(KeyCode.Space) && casting == false)
            {
                player_state = States.Walking;
                casting = true;
                fishing = false;
                animator.SetBool("fishing", false);
                StartCoroutine(cast_timer());
                DeckUI.GetComponent<scr_DeckUI>().canfish_trigger();
            }

            
        }
    }

    void FixedUpdate()
    {
        if(player_state == States.Walking)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        
    }

    public void StartReading()
    {
        prev_state = player_state;
        //Debug.Log("saved state: " + prev_state);
        player_state = States.Reading;
    }

    public void StopReading()
    {
        player_state = prev_state;
    }

    IEnumerator cast_timer()
    {
        yield return new WaitForSeconds(1f);
        casting = false;
    }

    IEnumerator fish_bite()
    {
        float wait = Random.Range(3f, 6f);

        yield return new WaitForSeconds(wait);

        if (fishing)
        {
            SceneManager.LoadScene(1);
        }

    }
}
