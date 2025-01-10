using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Animator animator;

    void Start()
    {
        currentHealth = maxHealth; // Inicializar la salud al máximo.
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Vida restante del enano: " + currentHealth);

        if (currentHealth <= 0)
        {
            animator.SetTrigger("DIE");
        }
    }

    private void Die()
    {
        Debug.Log("El enano ha muerto.");
        Destroy(gameObject); // Eliminar al enano.
    }
}
