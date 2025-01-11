using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    private bool treasureFound;
    public static event Action<bool> OnTreasureFound;


    void Start()
    {
        treasureFound = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        treasureFound = collision.gameObject.CompareTag("Wizard");
        OnTreasureFound?.Invoke(treasureFound);
    }
}
