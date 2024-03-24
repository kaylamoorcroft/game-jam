using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Threading;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int dmgDealt;
    [SerializeField] GameObject player;
    bool dying = false;

    float radius = 1f;
    int frames = 0;
    float hitcoolDown = 0;
    float blinkSpeed = 0.05f;
    SpriteRenderer sp;

    [SerializeField] AudioSource unitAudio;
    [SerializeField] AudioClip takeDamageSound;
    [SerializeField] AudioClip deathSound;

    public void Start()
    {
        if (!player) { player = GameObject.FindGameObjectWithTag("Player"); }
        if (!unitAudio) { unitAudio = GetComponent<AudioSource>(); }
        sp = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (dying == true)
        {
            //gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x / 1.3f, gameObject.transform.localScale.y / 1.3f, 0);
            frames++;
            if (frames == 25)
            {
                Destroy(gameObject);
                frames = 0;
            }
        }
        if (hitcoolDown <= 0) 
        {
            var collider = Physics2D.OverlapCircle(player.GetComponent<PlayerController>().attackPoint.transform.position, player.GetComponent<PlayerController>().radius, GameLayers.i.Enemy);
            if (collider != null && gameObject.CompareTag("Enemy") && player.GetComponent<PlayerController>().HitEnemy)
            {
                TakeDamage(player.GetComponent<Unit>().dmgDealt);
            }
            var collider2 = Physics2D.OverlapCircle(transform.position, radius, GameLayers.i.Enemy);
            if (collider2 != null && gameObject.tag == "Player")
            {
                TakeDamage(collider2.GetComponent<Unit>().dmgDealt);
            }
        }
        
        else
        {
            float betweenBlinks = 0f;
            if (betweenBlinks <= 0)
            {
                sp.enabled = !sp.enabled;
                betweenBlinks = blinkSpeed;
            }
        }

        hitcoolDown -= Time.deltaTime;
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            dying = true;
            unitAudio.PlayOneShot(deathSound, 1f);   
        }
        else
        {
            unitAudio.PlayOneShot(takeDamageSound, 1f);
        }        
        hitcoolDown = 0.5f;
    }

    public int GetHealth() { return health; }

    public bool GetDying() { return dying; }
}
