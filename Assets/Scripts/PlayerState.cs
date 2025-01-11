using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static PlayerState Instance { get; set; }
    public float currentHealth; // we want to see it in the isnpector, but we can change it later..
    public float maxHealth;
    public static event Action<bool> OnPlayerDeath;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void SetHealth(float newHealth) 
    { 
        currentHealth = newHealth;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage) 
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            OnPlayerDeath?.Invoke(true);
            Debug.Log("Player is dead");
            Destroy(gameObject);
        }
        else
        {
            OnPlayerDeath?.Invoke(false);
        }
        
    }

}
