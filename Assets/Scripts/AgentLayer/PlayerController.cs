using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 6f;
    [SerializeField] private float walkBackwardsSpeed = 4f;
    [SerializeField] private float runSpeed = 12f;
    [SerializeField] private float rotateSpeed = 120f;
    [SerializeField] private float jumpForce = 7f;
    private bool isWalking = false;
    private bool isJumping = true;
    private bool isAttacking = false;
    private bool isJumpAttacking = false;
    private float moveSpeed;
    private bool isGrounded;
    private Animator animator;
    private Rigidbody rb;
    private List<string> booleanAnimatorParameterNames;

    [SerializeField] private SpellFactory spellFactory;
    private float spellSpeed = 10f;
    private float maxSpellDistance = 10f;

    public bool allowInput = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
        animator.SetBool("walkRight", false);
        animator.SetBool("walkLeft", false);
        animator.SetBool("idle", true);
        booleanAnimatorParameterNames = GetBooleanParameterNames();
    }

    void Update()
    {
        if (!allowInput)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            return;
        }

        if (!isAttacking || isJumpAttacking)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);
                if (!isWalking && !isJumping)
                {
                    animator.SetBool("walkRight", true);
                    animator.SetBool("walkLeft", false);
                    animator.SetBool("idle", false);
                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
                if (!isWalking && !isJumping)
                {
                    animator.SetBool("walkLeft", true);
                    animator.SetBool("walkRight", false);
                    animator.SetBool("idle", false);
                }
            }
            else if (!isJumping)
            {
                animator.SetBool("walkRight", false);
                animator.SetBool("walkLeft", false);
                animator.SetBool("idle", true);
            }

            moveSpeed = walkSpeed;
            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    moveSpeed = runSpeed;
                    if (!isJumping)
                    {
                        ActivateAnimation("sprint");
                    }
                }
                else
                {
                    if (!isJumping)
                    {
                        ActivateAnimation("walk");
                    }
                }

                Vector3 moveDirection = transform.forward * moveSpeed;
                rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);
                isWalking = true;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Vector3 moveDirection = -transform.forward * walkBackwardsSpeed;
                rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);
                if (!isJumping)
                {
                    ActivateAnimation("walkback");
                }
                isWalking = true;
            }
            else
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
                if (isWalking && !isJumping)
                {
                    ActivateAnimation("idle");
                    isWalking = false;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isJumping)
        {
            Jump();
        }

        if (!isAttacking && !isJumping)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                ThrowSpell("Fire");
            }
        }
    }

    private List<string> GetBooleanParameterNames()
    {
        List<string> booleanParameterNames = new List<string>();
        foreach (var parameter in animator.parameters)
        {
            if (parameter.type == AnimatorControllerParameterType.Bool)
            {
                booleanParameterNames.Add(parameter.name);
            }
        }
        return booleanParameterNames;
    }

    private void ActivateAnimation(string animationToActive)
    {
        foreach (string animation in booleanAnimatorParameterNames)
        {
            if (animation != animationToActive)
            {
                animator.SetBool(animation, false);
            }
            else
            {
                animator.SetBool(animation, true);
            }
        }
    }

    private void ThrowSpell(string spellType)
    {
        isAttacking = true;
        ActivateAnimation("attack");

        Vector3 spawnPosition = transform.position + transform.forward * 1.5f + Vector3.up;
        GameObject spellInstance = spellFactory.CreateSpell(spellType, spawnPosition, transform.rotation);

        Rigidbody spellRb = spellInstance.GetComponent<Rigidbody>();
        if (spellRb == null)
        {
            spellRb = spellInstance.AddComponent<Rigidbody>();
        }

        spellRb.useGravity = false;
        spellRb.constraints = RigidbodyConstraints.FreezeRotation;
        spellRb.velocity = transform.forward * spellSpeed;

        StartCoroutine(DestroySpellAfterDistance(spellInstance, spellRb));
        StartCoroutine(EndAttackAnimation());
    }

    private IEnumerator EndAttackAnimation()
    {
        yield return new WaitForSeconds(0.20f);
        animator.SetBool("attack", false);
        isAttacking = false;

        if (isWalking)
        {
            ActivateAnimation("walk");
        }
        else
        {
            ActivateAnimation("idle");
        }
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
        isJumping = true;
        ActivateAnimation("jump");
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
                isJumping = false;
                animator.SetBool("jump", false);

                if (!isAttacking)
                {
                    if (isWalking)
                    {
                        ActivateAnimation("walk");
                    }
                    else
                    {
                        ActivateAnimation("idle");
                    }
                }
                break;
            }
        }
    }
}