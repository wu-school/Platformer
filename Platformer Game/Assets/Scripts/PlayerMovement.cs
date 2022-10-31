using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float m_speed = 4.0f;
    [SerializeField] float m_jumpForce = 7.5f;

    
    //private Animator m_animator;
    private Rigidbody2D m_body2d;

    private int m_facingDirection = 1;
    bool grounded = true;
    int maxjumps = 3;
    int jumps = 3;
    bool fastfall = false;
    float delayToIdle;

    // Start is called before the first frame update
    void Start()
    {
        //m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        refreshJumps();    
        
        //check if falling
        if(!grounded && m_body2d.velocity.y<0)
        {
            // trigger_falling
        }

        //flip sprite according to facing direction
        float inputX = Input.GetAxis("Horizontal");

        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            m_facingDirection = 1;
            m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);
        }

        else if (inputX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            m_facingDirection = -1;
            m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);
        }

        float inputY = Input.GetAxis("Vertical");

        if (inputY < 0)
        {
            m_body2d.gravityScale = 2;
        }
        else
        {
            m_body2d.gravityScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumps>0)
        { 
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            //m_animator.SetTrigger("Jump");
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
        }
    }

}
