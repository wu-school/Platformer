using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float m_speed = 4.0f;
    [SerializeField] float m_jumpForce = 7.5f;

    
    private Animator m_animator;
    private Rigidbody2D m_body2d;

    private int m_facingDirection = 1;
    bool grounded = false;
    int maxjumps = 3;
    int jumps = 3;
    bool fastfall = false;


    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        refreshJumps();    
        
        //check if landed
        if(!grounded && )

    }

    void refreshJumps()
    {
        if (grounded)
        {
            jumps = maxjumps;
        }
    }

}
