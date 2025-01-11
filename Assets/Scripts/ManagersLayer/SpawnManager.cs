using SpellboundForest.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private static SpawnManager _instance;
    public static SpawnManager Instance => _instance;

    [SerializeField] private GameObject treasurePrefab;
    private GameObject treasure;
    public GameObject Treasure => treasure;

    private GameObject wizard;

    private List<Vector3> wizardSpawnPoints = new List<Vector3>();
    private List<Vector3> treasureSpawnPoints = new List<Vector3>();

    public List<GameObject> Wizards = new List<GameObject>();
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            InitializeWizardSpawnPoints();
            InitializeTreasureSpawnPoints();
            wizard = GameObject.Find("Wizard1");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnWizard(bool isMultiplayer)
    {
        if (!isMultiplayer)
        {
            if (wizard != null)
            {
                int randomAppearancePointIndex = UnityEngine.Random.Range(0, wizardSpawnPoints.Count);
                wizard.transform.position = wizardSpawnPoints[randomAppearancePointIndex];
                Wizards.Add(wizard);
            }
            else
            {
                Debug.LogError("No se encontró el objeto 'Wizard1' en la escena");
            }
        }
    }

    public void InitializeWizardSpawnPoints()
    {
        wizardSpawnPoints = new List<Vector3>()
        {
            new Vector3(755.3236f, 9.474333f, 157.1007f),
            new Vector3(722.4654f, 19.87023f, 422.4689f),
            new Vector3(902.062f, 7.008363f, 295.6882f),
            new Vector3(530.7039f, 6.1904f, 314.0964f),
            new Vector3(546.5419f, 6.190442f, 369.67f),
            new Vector3(381.05f, 6.153819f, 340.6833f),
            new Vector3(293.9341f, 6.147651f, 338.002f),
            new Vector3(645f, 45.96777f, 541.7389f),
            new Vector3(624.6567f, 2.460966f, 739.4619f),
            new Vector3(496.1274f, 14.47593f, 628.1271f)
        };
    }

    public void InitializeTreasureSpawnPoints()
    {
        treasureSpawnPoints = new List<Vector3>()
        {
            new Vector3(725.7041f, 9.671993f, 136.3676f),
            new Vector3(66.69225f, 39.50972f, 128.7362f),
            new Vector3(725.7041f, 9.671993f, 136.3676f),
            new Vector3(725.7041f, 9.671993f, 136.3676f),
            new Vector3(725.7041f, 9.671993f, 136.3676f)
        };
    }

    public void SpawnTreasure()
    {
        int randomAppearancePointIndex = UnityEngine.Random.Range(0, treasureSpawnPoints.Count);
        treasure = Instantiate(treasurePrefab, treasureSpawnPoints[randomAppearancePointIndex], Quaternion.identity);
    }
}
