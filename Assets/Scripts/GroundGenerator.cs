using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject groundPrefab;
    private int numPrefabsWidth = 20;
    private int numPrefabsHeight = 20;
    private Vector3 groundPrefabSize;


    // Start is called before the first frame update
    void Start()
    {
        groundPrefabSize = groundPrefab.GetComponent<Renderer>().bounds.size;
        GenerateGround();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateGround()
    {
        for (int x = 0; x < numPrefabsWidth; x++)
        {
            for (int z = 0; z < numPrefabsHeight; z++)
            {
                Vector3 position = new Vector3(x * groundPrefabSize.x, transform.position.y, z * groundPrefabSize.z);
                Instantiate(groundPrefab, position, Quaternion.identity, transform);
            }
        }
    }

    public int GetNumPrefabsWidth()
    {
        return numPrefabsWidth;
    }

    public int GetNumPrefabsHeight()
    {
        return numPrefabsHeight;
    }

    public Vector3 GetGroundPrefabSize()
    {
        return groundPrefabSize;
    }
}
