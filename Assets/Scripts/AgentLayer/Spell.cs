using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public int damage = 20; // Da�o que causa el hechizo.

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto colisionado tiene el script de salud.
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            // Aplicar da�o al enemigo.
            enemyHealth.TakeDamage(damage);

            // Opcional: destruir el hechizo tras impactar.
            Destroy(gameObject);
        }
    }
}

