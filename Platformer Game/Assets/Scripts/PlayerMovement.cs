using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float m_speed = 4.0f;
    [SerializeField] float m_jumpForce = 7.5f;
    [SerializeField] float default_gravity = 1.4f;
    [SerializeField] float fast_fall_multiplier = 3f;
    [SerializeField] PlatformGenerator myController;
    [SerializeField] RuntimeAnimatorController walk, idle, fall, jump;
    private Rigidbody2D m_body2d;

    private int m_facingDirection = 1;
    bool grounded = true;
    int maxjumps = 3;
    public int jumps = 3;
    bool fastfall = false;
    float delayToIdle;
    int points = 0;
    [SerializeField] bool falling = false;


    // Start is called before the first frame update
    void Start()
    {
        //m_animator = GetComponent<Animator>();
        gameObject.GetComponent<SpriteRenderer>().size += new Vector2(5,5);
        m_body2d = GetComponent<Rigidbody2D>();
        myController = GameObject.Find("Controller").GetComponent<PlatformGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -8)
        {
            Debug.Log("u ded");
            SceneManager.LoadScene("Lose");
            myController.stopGeneration();
            GameObject.Find("Controller").GetComponent<JumpCounter>().enabled = false;
        }


        refreshJumps();    
        
        //check if falling
        if( m_body2d.velocity.y<0)
        {
            gameObject.GetComponent<Animator>().SetBool("Falling", true);
            falling = true;
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Falling", false);
            falling = false;
        }

        //flip sprite according to facing direction
        float inputX = Input.GetAxis("Horizontal");
        //print(inputX);

        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
        {
            gameObject.GetComponent<Animator>().SetBool("Idle", false);

            GetComponent<SpriteRenderer>().flipX = false;
            m_facingDirection = 1;
            m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);
            if (grounded)
            {
                gameObject.GetComponent<Animator>().SetBool("Walking", true);
            }
        }

        else if (inputX < 0)
        {
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
            GetComponent<SpriteRenderer>().flipX = true;
            m_facingDirection = -1;
            m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);
            if (grounded)
            {
                gameObject.GetComponent<Animator>().SetBool("Walking", true);
            }
        }
        else
        {
            if (grounded)
            {
                gameObject.GetComponent<Animator>().SetBool("Idle", true);
            }
        }

        float inputY = Input.GetAxis("Vertical");

        if (inputY < 0)
        {
            m_body2d.gravityScale = fast_fall_multiplier*default_gravity ;
            gameObject.GetComponent<Animator>().SetBool("Fast Fall", true);
        }
        else
        {
            m_body2d.gravityScale = default_gravity;
            gameObject.GetComponent<Animator>().SetBool("Fast Fall", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumps>0)
        { 
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            gameObject.GetComponent<Animator>().SetTrigger("Jump");
            grounded = false;
            //m_animator.SetBool("Grounded", grounded);
            jumps--;
        }

        else if (Mathf.Abs(inputX) > Mathf.Epsilon)
        {
            // Reset timer
            delayToIdle = 0.05f;
            //m_animator.SetInteger("AnimState", 1);
        }

        //Idle
        else
        {
            // Prevents flickering transitions to idle
            delayToIdle -= Time.deltaTime;
            if (delayToIdle < 0)
            {

            }
              //  m_animator.SetInteger("AnimState", 0);
        }

        if (transform.position.y < -9)
        {
            GameObject myController = GameObject.Find("Controller");

        }
    }

    void refreshJumps()
    {
        if (grounded)
        {
            jumps = maxjumps;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.position.y < transform.position.y)
        {
            grounded = true;
            points++;
        }
    }

}
