using UnityEngine;
using System.Collections.Generic; 
using UnityEngine.AI;

public class DwarfFactory : MonoBehaviour
{
    public GameObject dwarfPrefab;
    public float navMeshCheckRadius = 2f;

    private List<Vector3> spawnPositions = new List<Vector3>()
    {
        new Vector3(901f, 7.008363f, 297f),
        new Vector3(850f, 7.008363f, 300f),
        new Vector3(844f, 7.008363f, 250f),
        new Vector3(820, 56, 559),
        new Vector3(760,9.08f,180),
        new Vector3(730,9.07999992f,150),
        new Vector3(723f, 19.87023f, 421f),
        new Vector3(710f, 19.87023f, 405f),
        new Vector3(700,56,237),
        new Vector3(685.23999f,9.07999992f,186.089996f),
        new Vector3(660f, 45.96777f, 533f),
        new Vector3(653f, 9.671993f, 150f),
        new Vector3(630f, 45.96777f, 560f),
        new Vector3(610f, 2.460966f, 745f),
        new Vector3(560f, 6.1904f, 330f),
        new Vector3(552f,20,540f),
        new Vector3(541f,9.07999992f,293.899994f),
        new Vector3(530f, 6.190442f, 370f),
        new Vector3(516,56,322),
        new Vector3(470f, 14.47593f, 628f),
        new Vector3(449f,20,386f),
        new Vector3(415f,20,625f),
        new Vector3(387f, 6.153819f, 345f),
        new Vector3(383,56,322),
        new Vector3(375f, 6.153819f, 340f),
        new Vector3(369,56,559),
        new Vector3(300,20,600f),
        new Vector3(280, 6.147651f, 325f),
        new Vector3(270f,20,625f),
        new Vector3(262,56,498f),
        new Vector3(257f,9.07999992f,402f),
        new Vector3(120f,20,540f),
        new Vector3(75f, 39.50972f, 129f)
    };
    

    void Start()
    {
        GenerateDwarves();
    }

    private Vector3 GetPositionOnNavMesh(Vector3 originalPosition)
    {
        float terrainHeight = Terrain.activeTerrain.SampleHeight(originalPosition);
        Vector3 adjustedPosition = new Vector3(originalPosition.x, terrainHeight, originalPosition.z);

        NavMeshHit hit;
        if (NavMesh.SamplePosition(adjustedPosition, out hit, navMeshCheckRadius, NavMesh.AllAreas))
        {
            return hit.position; 
        }
        else
        {
            return Vector3.zero;
        }
    }

    public void GenerateDwarves()
    {

        for (int i = 0; i < spawnPositions.Count; i++) 
        {
            Vector3 adjustedPosition = GetPositionOnNavMesh(spawnPositions[i]);
            Instantiate(dwarfPrefab, adjustedPosition, Quaternion.identity);
        }
    }
}

