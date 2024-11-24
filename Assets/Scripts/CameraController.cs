using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 position = transform.position;
            position.x = player.transform.position.x;
            position.z = player.transform.position.z - 10;
            position.y = player.transform.position.y+10;
            transform.position = position;
        }
    }
}
