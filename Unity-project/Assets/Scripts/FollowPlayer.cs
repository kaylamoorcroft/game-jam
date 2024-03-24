using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float smoothing = 1f; // controls how smooth camera moves

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
            Vector3 newCameraPos = player.transform.position;
            newCameraPos.x += offsetX;
            newCameraPos.y += offsetY;
            newCameraPos.z = -10f;
            transform.position = Vector3.Lerp(transform.position, newCameraPos, smoothing * Time.deltaTime);
        }
    }
}
