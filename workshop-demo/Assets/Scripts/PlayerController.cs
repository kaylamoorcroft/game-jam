using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float jumpAmount = 30f;
    Rigidbody2D rb;
    float currentMoveSpeed;
    Vector2 movement;
    float shootCooldown;
    [SerializeField] private GameObject restartButton;
    Animator animator;


    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentMoveSpeed = moveSpeed;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Debug.Log(movement);
        //Vector2(x,y)
        //when A or Left is held, x = -1 if D or Right is held, x = 1 else x = 0
        movement.x = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if (Input.GetKeyDown(KeyCode.W))
            Jump();

        if (Input.GetMouseButton(0) && shootCooldown <= 0)
        {
            GetComponentInChildren<ProjectileSpawner>().SpawnProjectile();
            shootCooldown = 0.25f;
        }
    }

    // Use FixedUpdate as it is executed on a fixed timer (default = 50times/second)
    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x, rb.velocity.y);

        animator.SetFloat("MovementDirection", movement.x);

        if (shootCooldown > 0)
        {
            shootCooldown -= Time.fixedDeltaTime;
        }
    }

    void Jump()
    {
        Debug.Log(Vector2.up * jumpAmount);
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
    }

    void OnDestroy()
    {
        if (restartButton != null)
        {
            restartButton.SetActive(true);
        }
    }
}
