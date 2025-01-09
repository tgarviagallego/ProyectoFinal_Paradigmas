using SpellboundForest.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private static SpawnManager _instance;
    public static SpawnManager Instance => _instance;

    private SpellFactory spellFactory = FindObjectOfType<SpellFactory>();
    private MonsterFactory monsterFactory = FindObjectOfType<MonsterFactory>();

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = null;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnMonster(MonsterType type, Vector3 position)
    {
        monsterFactory.CreateMonster(type, position);
    }

    internal void InitializeSpawnPoints()
    {
        // throw new NotImplementedException();
    }

    internal void SpawnMultiplayerWizards()
    {
        throw new NotImplementedException();
    }

    internal void SpawnSinglePlayerWizard()
    {
        throw new NotImplementedException();
    }
}
