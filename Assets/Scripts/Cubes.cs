using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    [SerializeField] private CubeSwipe[] cubeSpiwe;

    private void Start()
    {
        cubeSpiwe = GetComponentsInChildren<CubeSwipe>();
    }

    public void DisableCubesDrag()
    {
        if(cubeSpiwe.Length > 0)
        {
           foreach (var c in cubeSpiwe)
           {
                c.DisableMovement();
           }
        }
    }
}
