using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3.0f;
    Rigidbody2D rb;
    Transform player;
    Vector2 moveDirection;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player && !GameController.i.isPaused)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            moveDirection = direction;
        }
    }

    void FixedUpdate() 
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);

        animator.SetFloat("Movement", rb.velocity.x);

        bool dying = GetComponent<Unit>().GetDying();
        if(!dying)
        {
            if(rb.velocity.x < 0)
                transform.localScale = new Vector3(1, 1, 1);

            if(rb.velocity.x > 0)
                transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
