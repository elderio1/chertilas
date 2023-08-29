using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

[RequireComponent(typeof(Rigidbody2D))]

public class CharacterController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 2f;
    Vector2 motionVector;
    public Vector2 lastMotionVector;
    Animator animator;
    public bool moving;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        motionVector = new Vector2(
            Horizontal, 
            Vertical
            
            );
        animator.SetFloat("Horizontal", Horizontal);
        animator.SetFloat("Vertical", Vertical);

        moving = Horizontal != 0 || Vertical != 0;
        animator.SetBool("moving", moving);

        if (Horizontal != 0 || Vertical != 0)
        {
            lastMotionVector = new Vector2(
                Horizontal,
                Vertical
                ).normalized;
            animator.SetFloat("lastHorizontal", Horizontal);
            animator.SetFloat("lastVertical", Vertical);        

        }

    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = motionVector * speed;
    }
}
