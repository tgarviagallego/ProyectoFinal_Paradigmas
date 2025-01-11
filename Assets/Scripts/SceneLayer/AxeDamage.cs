using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AxeDamage : MonoBehaviour
{
    public int damageToInflict = 1;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Wizard")) 
        {
            
            PlayerState.Instance.TakeDamage(damageToInflict); 
        }
    }
}
