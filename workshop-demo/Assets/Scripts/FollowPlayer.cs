using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float smoothing = 1f; // controls how smooth camera moves
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
            Vector3 newCameraPos = playerPosition;
            if (playerPosition.y < 0) // if below middle of screen
            {
                newCameraPos.y += offsetY; // camera should be higher than usual by offset amount, otherwise, in middle of screen
            }
            newCameraPos.x += offsetX;
            newCameraPos.z = -10f;
            transform.position = Vector3.Lerp(transform.position, newCameraPos, smoothing * Time.deltaTime);
        }
    }
}
