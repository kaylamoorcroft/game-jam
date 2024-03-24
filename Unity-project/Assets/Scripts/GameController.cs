using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool isPaused = true;
    public float respawnTimer = 42f;
    public static GameController i { get; set; }

    private void Awake()
    {
        i = this;
    }

    private void FixedUpdate()
    {
        if(isPaused)    
            respawnTimer--;
        
        if(respawnTimer == 0)
            isPaused = false;
    }
}
