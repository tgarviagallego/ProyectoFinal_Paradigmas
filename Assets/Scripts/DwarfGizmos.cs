using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfGizmos : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 7f);//attack distance

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 18f);//start chasing distance

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 21f);//stop chasing
    }
}
