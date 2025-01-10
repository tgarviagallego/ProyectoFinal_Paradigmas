using UnityEngine;

public class DwarfController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Ataque básico
        if (Input.GetKeyDown(KeyCode.Alpha1)) // Presiona 1 para Attack1
        {
            animator.Play("Attack1");
        }

        // Correr
        if (Input.GetKeyDown(KeyCode.R)) // Presiona R para Run
        {
            animator.Play("Run");
        }

        // Muerte
        if (Input.GetKeyDown(KeyCode.D)) // Presiona D para Death1
        {
            animator.Play("Death1");
        }
    }
}
