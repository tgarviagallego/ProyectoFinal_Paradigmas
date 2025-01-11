using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AxeDamage : MonoBehaviour
{
    NavMeshAgent agent;
    Transform player;
    public int damageToInflict = 5; // Da�o infligido por el hacha.

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Wizard")) 
        {
            Debug.Log("paso aqu�");
            PlayerState.Instance.TakeDamage(damageToInflict);
            Debug.Log("El jugador ha recibido da�o del hacha.");
            
        }
    }
}
