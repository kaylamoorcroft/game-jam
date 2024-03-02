using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] GameObject projectileObject;
    [SerializeField] Camera cam;
    Transform aimer;
    public float bulletForce = 5f;
    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        aimer = gameObject.transform;
        if (!cam)
        {
            cam = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void SpawnProjectile()
    {
        Vector2 direction = (mousePos - (Vector2)aimer.position).normalized;

        GameObject bullet = Instantiate(projectileObject, aimer.position, aimer.rotation);
        //bullet.GetComponent<NetworkObject>().Spawn(true);

        // Access the bullet's rigidbody and store it as rb
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Add force to the newly instantiated rb
        rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);
    }
}
