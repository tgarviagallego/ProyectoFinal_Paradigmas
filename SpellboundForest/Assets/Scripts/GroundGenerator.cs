using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject[] groundPrefabs;
    private int width = 100;
    private int height = 100;
    private float spacing = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        GenerateGround();
    }

    private void GenerateGround()
    {
        for (int x=0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
