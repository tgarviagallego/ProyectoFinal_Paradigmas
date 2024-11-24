using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private float horizontal;
    private float vertical;
    private bool isGrounded;

    private Animator animator;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animator.SetBool("jumping", true);
            Jump();
        }
    }

    private void HandleRotation()
    {
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localRotation = Quaternion.Euler(0.0f, -45.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            transform.localRotation = Quaternion.Euler(0.0f, 45.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localRotation = Quaternion.Euler(0.0f, 225.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            transform.localRotation = Quaternion.Euler(0.0f, 135.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localRotation = Quaternion.Euler(0.0f, transform.localRotation.y + 90.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localRotation = Quaternion.Euler(0.0f, transform.localRotation.y - 90.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.localRotation = Quaternion.Euler(0.0f, transform.localRotation.y, 0.0f);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.localRotation = Quaternion.Euler(0.0f, transform.localRotation.y + 180.0f, 0.0f);
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(horizontal * speed, rb.velocity.y, vertical * speed);
        animator.SetBool("running", (horizontal != 0.0f) || (vertical != 0.0f));
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.normal.y > 0.7f)
            {
                isGrounded = true;
                animator.SetBool("jumping", false);
                break;
            }
        }
    }
}
