using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3.0f;
    Rigidbody2D rb;
    Transform player;
    Vector2 moveDirection;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            moveDirection = direction;
        }
    }

    void FixedUpdate() 
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
    }
}
