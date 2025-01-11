using System;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 3.0f;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceFromTarget = 3.0f;
    [SerializeField] private float smoothTime = 0.2f;
    [SerializeField] private float verticalOffset = 1.5f;
    [SerializeField] private float rotationXLimit = 40f;
    [SerializeField] private float zoomSpeed = 2.0f; 
    [SerializeField] private float minZoomDistance = 1.0f; 
    [SerializeField] private float maxZoomDistance = 10.0f; 

    private float rotationY;
    private float rotationX;
    private Vector3 currentRotation;
    private Vector3 smoothVelocity = Vector3.zero;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;    
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationY += mouseX;
        rotationX -= mouseY;

        rotationX = Mathf.Clamp(rotationX, -rotationXLimit, rotationXLimit);

        Vector3 nextRotation = new Vector3(rotationX, rotationY);
        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation,ref smoothVelocity, smoothTime);

        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);

        transform.position = target.position - transform.forward * distanceFromTarget + transform.up * verticalOffset;

        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0)
        {
            distanceFromTarget -= scrollInput * zoomSpeed;
            distanceFromTarget = Mathf.Clamp(distanceFromTarget, minZoomDistance, maxZoomDistance);
        }
    }
}