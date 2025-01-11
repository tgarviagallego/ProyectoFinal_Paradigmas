using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public int damageToInflict = 20; 

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Dwarf"))
        {

            DwarfState.Instance.TakeDamage(damageToInflict);
            //Debug.Log("Auch!");

        }
    }
}

