using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    public GameObject fireSpell;
    public GameObject iceSpell;
    public GameObject deadSpell;
    public float spellSpeed = 5f;
    public float maxSpellDistance = 10f;

    [SerializeField] private float rotationSpeed = 50f;

    private float horizontal;
    private bool isGrounded;

    private Animator animator;
    private Rigidbody rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            ThrowSpell(fireSpell);
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            ThrowSpell(iceSpell);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            ThrowSpell(deadSpell);
        }
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal != 0)
        {
            Quaternion targetRotation = Quaternion.Euler(0.0f, horizontal * rotationSpeed * Time.fixedDeltaTime, 0.0f);
            rb.MoveRotation(rb.rotation * targetRotation);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 forwardMovement = transform.forward * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + forwardMovement);
        }
        animator.SetBool("running", Input.GetKey(KeyCode.UpArrow));
    }

    private void ThrowSpell(GameObject spell)
    {
        animator.SetBool("attacking", true);
        Vector3 spawnPosition = transform.position + transform.forward * 1.5f + new Vector3(0, 1, 0);
        GameObject spellInstance = Instantiate(spell, spawnPosition, transform.rotation);

        Rigidbody spellRb = spellInstance.GetComponent<Rigidbody>();
        if (spellRb == null)
        {
            spellRb = spellInstance.AddComponent<Rigidbody>();
        }

        spellRb.useGravity = false;
        spellRb.constraints = RigidbodyConstraints.FreezeRotation;

        Vector3 spellDirection = transform.forward;

        spellRb.velocity = spellDirection * spellSpeed;

        StartCoroutine(DestroySpellAfterDistance(spellInstance, spellRb));
        StartCoroutine(EndAttackAnimation());
    }

    private IEnumerator EndAttackAnimation()
    {
        yield return new WaitForSeconds(0.20f);
        animator.SetBool("attacking", false);
    }

    private IEnumerator DestroySpellAfterDistance(GameObject spellObj, Rigidbody spellRb)
    {
        Vector3 startPosition = spellObj.transform.position;

        while (spellObj != null)
        {
            float distanceTraveled = Vector3.Distance(startPosition, spellObj.transform.position);

            if (distanceTraveled >= maxSpellDistance)
            {
                Destroy(spellObj);
                yield break;
            }

            yield return null;
        }
    }

    private void Jump()
    {
        animator.SetBool("jumping", true);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
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
