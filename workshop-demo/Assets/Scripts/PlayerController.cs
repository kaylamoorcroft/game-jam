using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpAmount;

    Rigidbody2D rb;
    float currentMoveSpeed;
    Vector2 movement; //(0,0)
    float shootCooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal") * currentMoveSpeed;

        if (Input.GetKeyDown(KeyCode.W))    
            Jump();

        if(Input.GetMouseButtonDown(0) && shootCooldown <= 0)
        {
            Debug.Log("shoot");
            shootCooldown = 0.25f;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x, rb.velocity.y);

        if (shootCooldown > 0)
            shootCooldown -= Time.fixedDeltaTime;
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
    }
}
