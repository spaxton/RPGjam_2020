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

    public enum States
    {
        Reading,
        Walking,
        Sitting,
        Fishing
    }
    public States player_state = States.Walking;

    public bool can_fish = false;
    private bool casting = false;
    private bool fishing;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
            }

            if (fishtarget.GetComponent<scr_fishtarget>().can_fish == true)
            {
                can_fish = true;
                //Debug.Log("can fish");
            }
            else
            {
                can_fish = false;
                //Debug.Log("can't fish");
            }

            if (Input.GetKeyDown(KeyCode.Space) && casting == false && can_fish)
            {
                player_state = States.Fishing;
                casting = true;
                fishing = true;
                animator.SetBool("fishing", true);
                StartCoroutine(cast_timer());
                StartCoroutine(fish_bite());
            }

        }

        


        if (player_state == States.Fishing)
        {
            if (Input.GetKeyDown(KeyCode.Space) && casting == false)
            {
                player_state = States.Walking;
                casting = true;
                fishing = false;
                animator.SetBool("fishing", false);
                StartCoroutine(cast_timer());
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
