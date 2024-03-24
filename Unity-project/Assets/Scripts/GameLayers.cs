using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLayers : MonoBehaviour
{
    [SerializeField] LayerMask terrain;
    [SerializeField] LayerMask ground;
    [SerializeField] LayerMask enemy;

    public static GameLayers i { get; set; }

    private void Awake()
    {
        i = this;
    }

    public LayerMask TerrainLayer
    {
        get => terrain;
    }

    public int GroundLayer
    {
        get => ground;
    }

    public LayerMask Enemy
    {
        get => enemy;
    }
}
