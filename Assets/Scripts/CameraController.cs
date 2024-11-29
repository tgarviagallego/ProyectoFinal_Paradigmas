using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0, 5, 10);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 desiredPosition = player.transform.position + offset;

            Quaternion rotation = Quaternion.Euler(0.0f, player.transform.rotation.eulerAngles.y, 0.0f);

            transform.position = player.transform.position - rotation*offset;

            transform.LookAt(player.transform);
        }
    }
}
