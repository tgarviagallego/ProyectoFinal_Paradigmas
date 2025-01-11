using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    private Slider slider;

    public TMP_Text healthCounter;

    public GameObject playerState;

    private float currentHealth;
    private float maxHealth;

    void Awake() 
    {
        slider = GetComponent<Slider>();

    }

    private void FixedUpdate()
    {
        if (playerState == null)
        {
            return; 
        }

        PlayerState playerStateComponent = playerState.GetComponent<PlayerState>();
        if (playerStateComponent == null)
        {
            return;
        }
        currentHealth = playerState.GetComponent<PlayerState>().currentHealth; 
        maxHealth = playerState.GetComponent<PlayerState>().maxHealth;

        float fillValue = currentHealth / maxHealth; //0-1
        slider.value = fillValue; // se llena la barrita

        healthCounter.text = currentHealth + "/" + maxHealth;

    }
}
