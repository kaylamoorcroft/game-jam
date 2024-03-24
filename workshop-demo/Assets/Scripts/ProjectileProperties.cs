using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileProperties : MonoBehaviour
{
    public int damage = 5;

    private void FixedUpdate()
    {
        onCollisionEnter();
    }

     public void onCollisionEnter()
    {
        var collider = Physics2D.OverlapCircle(transform.position, 0.3f,GameLayers.i.TerrainLayer);
        if (collider != null) //Destory on collision with border
        {
            Debug.Log("hit border");
            Destroy(gameObject);
        }
    }
}
