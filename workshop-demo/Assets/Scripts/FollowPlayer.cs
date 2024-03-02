using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    private Vector2 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player) //Player was destroyed
        {
            playerPosition = player.transform.position;
            transform.position = new Vector3(playerPosition.x + offsetX, playerPosition.y + offsetY, -10f);
        }
    }
}
