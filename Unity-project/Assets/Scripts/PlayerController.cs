using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float jumpAmount = 30f;
    Rigidbody2D rb;
    Vector2 movement;
    float shootCooldown;
    bool onGround;
    float currentMoveSpeed;
    bool hitEnemy;
    [SerializeField] private GameObject restartButton;
    public GameObject attackPoint;
    [SerializeField] public float radius;

    Animator animator;
    [SerializeField] private AudioSource playerAudio;
    [SerializeField] private AudioClip jumpSound;


    public void Start()
    {
        if (!playerAudio) { playerAudio = GetComponent<AudioSource>(); }
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentMoveSpeed = moveSpeed;
        onGround = true;
    }

    void Update()
    {
        //Debug.Log(movement);
        //Vector2(x,y)
        //when A or Left is held, x = -1 if D or Right is held, x = 1 else x = 0
        if (!GameController.i.isPaused)
        {
            movement.x = Input.GetAxisRaw("Horizontal") * moveSpeed;

            if (Input.GetKeyDown(KeyCode.W))
                Jump();

            if (Input.GetMouseButton(0))
            {
                animator.SetBool("isAttacking", true);
            }
        }

    }

    // Use FixedUpdate as it is executed on a fixed timer (default = 50times/second)
    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x, rb.velocity.y);

        animator.SetFloat("Movement", rb.velocity.x);
        animator.SetFloat("JumpHeight", rb.velocity.y);
        animator.SetBool("Paused", GameController.i.isPaused);

        if (rb.velocity.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (rb.velocity.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        /*
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.fixedDeltaTime;
        }*/
    }

    void Jump()
    {
        if (onGround)
        {
            onGround = false;
            playerAudio.PlayOneShot(jumpSound, 1f);
            Debug.Log(Vector2.up * jumpAmount);
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
    }

    public void EndAttack()
    {
        animator.SetBool("isAttacking", false);
        hitEnemy = false;
    }

    public Collider2D Attack()
    {
        Collider2D enemy = Physics2D.OverlapCircle(attackPoint.transform.position, radius, GameLayers.i.Enemy);

        if (enemy)
        {
            Debug.Log("Hit enemy");
            hitEnemy = true;
        }
        else { hitEnemy = false; }
        return enemy;
    }

    void OnDestroy()
    {
        if (restartButton != null)
        {
            restartButton.SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10) // ground layer
        {
            onGround = true;
        }
    }
    // just to see where spear would hit

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }

    public bool HitEnemy
    {
        get { return hitEnemy; }
    }
}
