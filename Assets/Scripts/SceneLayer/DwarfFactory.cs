using UnityEngine;
using System.Collections.Generic; // Necesario para usar List.

public class DwarfFactory : MonoBehaviour
{
    public GameObject dwarfPrefab; // Prefab del enano.

    // Lista privada de posiciones predefinidas.
    private List<Vector3> spawnPositions = new List<Vector3>()
    {
        new Vector3(685.23999f,9.07999992f,186.089996f),
        new Vector3(730,9.07999992f,150),
        new Vector3(685.23999f,9.07999992f,307.899994f),
        new Vector3(541f,9.07999992f,293.899994f),
        new Vector3(257f,9.07999992f,402f),
        new Vector3(357f,9.07999992f,251f),
        new Vector3(726f,9.07999992f,636f),
        new Vector3(415f,20,625f),
        new Vector3(270f,20,625f),
        new Vector3(449f,20,386f),
        new Vector3(652f,20,544f),
        new Vector3(700,56,237),
        new Vector3(613,56,360),
        new Vector3(262,56,498),
        new Vector3(369,56,559),
        new Vector3(274,56,643),
        new Vector3(702,56,662),
        new Vector3(820, 56, 559),
        new Vector3(516,56,322),
        new Vector3(383,56,322),
        new Vector3(730,56,222),
    };

    void Start()
    {
        GenerateDwarves();
    }

    public void GenerateDwarves()
    {

        for (int i = 0; i < spawnPositions.Count; i++) 
        {
            Instantiate(dwarfPrefab,spawnPositions[i], Quaternion.identity);    
        }
    }
}

