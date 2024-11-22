using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalGenerator : MonoBehaviour
{
    public GameObject[] cristalPrefabs;
    public int numCristals = 20;
    public float minDistance = 2f;

    private float mapWidth;
    private float mapHeight;

    private GroundGenerator groundGenerator;

    private List<Vector3> occupiedPositions = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        groundGenerator = FindObjectOfType<GroundGenerator>();

        if (groundGenerator != null)
        {
            Vector3 groundPrefabSize = groundGenerator.GetGroundPrefabSize();
            mapWidth = groundGenerator.GetNumPrefabsWidth() * groundPrefabSize.x;
            mapHeight = groundGenerator.GetNumPrefabsHeight() * groundPrefabSize.z;
            GenerateTrees();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GenerateTrees()
    {
        int treesGenerated = 0;

        while (treesGenerated < numCristals)
        {
            float x = UnityEngine.Random.Range(0f, mapWidth);
            float z = UnityEngine.Random.Range(0f, mapHeight);
            Vector3 position = new Vector3(x, 0f, z);

            if (IsPositionFree(position))
            {
                GameObject treePrefab = cristalPrefabs[UnityEngine.Random.Range(0, cristalPrefabs.Length)];
                Instantiate(treePrefab, position, Quaternion.identity);
                occupiedPositions.Add(position);
                treesGenerated++;
            }
        }
    }

    private bool IsPositionFree(Vector3 position)
    {
        foreach (Vector3 occupiedPosition in occupiedPositions)
        {
            if (Vector3.Distance(position, occupiedPosition) < minDistance)
            {
                return false;
            }
        }
        return true;
    }
}
