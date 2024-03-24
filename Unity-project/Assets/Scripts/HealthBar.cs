using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthbar;
    [SerializeField] private Unit player;

    // Start is called before the first frame update
    void Start()
    {
        healthbar.maxValue = player.GetHealth();
        healthbar.minValue = 0;
        healthbar.value = player.GetHealth();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        healthbar.value = player.GetHealth();
    }
}
