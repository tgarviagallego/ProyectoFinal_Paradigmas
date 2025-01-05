using UnityEngine;
using UnityEngine.Rendering;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 3.0f;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceFromTarget = 3.0f;
    [SerializeField] private float smoothTime = 0.2f;
    [SerializeField] private float verticalOffset = 1.5f;

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

        rotationX = Mathf.Clamp(rotationX, -40, 40);

        Vector3 nextRotation = new Vector3(rotationX, rotationY);
        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation,ref smoothVelocity, smoothTime);

        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);

        transform.position = target.position-transform.forward*distanceFromTarget+transform.up*verticalOffset;
    }
}