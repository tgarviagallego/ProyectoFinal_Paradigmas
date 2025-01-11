using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DwarfState : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private Animator animator;
    public Slider healthBarSlider;

  

    void Start()
    {
        currentHealth = maxHealth;
        healthBarSlider.maxValue = maxHealth;
        healthBarSlider.value = currentHealth;
        animator = GetComponent<Animator>();
    }

    public void UpdateHealthBar()
    {
        healthBarSlider.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();

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
