using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DwarfState : MonoBehaviour
{
    public static DwarfState Instance { get; set; }
    public int maxHealth = 100;
    public int currentHealth; // Hacer público para acceso desde otros scripts.
    private Animator animator;
    public Slider healthBarSlider;

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

    void Start()
    {
        currentHealth = maxHealth;
        healthBarSlider.maxValue = maxHealth; // Configurar el valor máximo del slider.
        healthBarSlider.value = currentHealth; // Inicializar el slider con la salud actual.
        animator = GetComponent<Animator>();
    }

    public void UpdateHealthBar()
    {
        healthBarSlider.value = currentHealth; // Actualizar el slider.
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthBar(); // Llamar directamente al actualizar la vida.

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("DIE");
        Destroy(gameObject);
      
    }
}
