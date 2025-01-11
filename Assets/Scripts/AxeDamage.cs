using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AxeDamage : MonoBehaviour
{
    NavMeshAgent agent;
    Transform player;
    public int damageToInflict = 5; // Daño infligido por el hacha.

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Wizard")) 
        {
            Debug.Log("paso aquí");
            PlayerState.Instance.TakeDamage(damageToInflict);
            Debug.Log("El jugador ha recibido daño del hacha.");
            
        }
    }
}
