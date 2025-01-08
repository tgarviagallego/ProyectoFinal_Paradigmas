using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;

    public Text healthCounter;

    public GameObject playerState;

    private float currentHealth;
    private float maxHealth;

    void Awake() 
    {
        slider = GetComponent<Slider>();

    }

    private void FixedUpdate()
    {
        currentHealth = playerState.GetComponent<PlayerState>().currentHealth; // to be done yet
        maxHealth = playerState.GetComponent<PlayerState>().maxHealth;

        float fillValue = currentHealth / maxHealth; //0-1
        slider.value = fillValue; // se llena la barrita

        healthCounter.text = currentHealth + "/" + maxHealth;

    }
}
