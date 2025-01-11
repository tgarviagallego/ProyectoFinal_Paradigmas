using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AxeDamage : MonoBehaviour
{
    //Transform player;
    public int damageToInflict = 2; // Daño infligido por el hacha.

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Wizard")) 
        {
            
            PlayerState.Instance.TakeDamage(damageToInflict); 
            //Debug.Log("Wizard! You are being hurt by the dwarf!.");
            
        }
    }
}
