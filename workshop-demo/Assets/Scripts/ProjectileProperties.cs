using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileProperties : MonoBehaviour
{
    [SerializeField] int damage;

    private void FixedUpdate()
    {
        onCollisionEnter();
    }

    void onCollisionEnter()
    {
        var collider = Physics2D.OverlapCircle(transform.position, 0.1f, GameLayers.i.TerrainLayer);
        if(collider != null)
        {
            Debug.Log("hit border");
            Destroy(gameObject);
        }
    }
}
