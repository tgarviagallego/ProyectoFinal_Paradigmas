//using UnityEngine;

//public class DragonExample : MonoBehaviour
//{
//    private Animator anim;

//    private int idleSimpleHash;
//    private int walkHash;
//    private int battleStanceHash;
//    private int biteHash;
//    private int drakarisHash;
//    private int flyingFWDHash;
//    private int flyingAttackHash;
//    private int hoverHash;
//    private int landsHash;
//    private int takeOffHash;
//    private int dieHash;

//    void Start()
//    {
//        anim = GetComponent<Animator>();

//        // Inicializar hashes
//        idleSimpleHash = Animator.StringToHash("IdleSimple");
//        walkHash = Animator.StringToHash("Walk");
//        battleStanceHash = Animator.StringToHash("BattleStance");
//        biteHash = Animator.StringToHash("Bite");
//        drakarisHash = Animator.StringToHash("Drakaris");
//        flyingFWDHash = Animator.StringToHash("FlyingFWD");
//        flyingAttackHash = Animator.StringToHash("FlyingAttack");
//        hoverHash = Animator.StringToHash("Hover");
//        landsHash = Animator.StringToHash("Lands");
//        takeOffHash = Animator.StringToHash("TakeOff");
//        dieHash = Animator.StringToHash("Die");
//    }

//    void Update()
//    {
//        HandleInput();
//    }

//    private void HandleInput()
//    {
//        if (Input.GetKeyDown(KeyCode.W))
//        {
//            SetAnimatorState(walkHash);
//        }
//        else if (Input.GetKeyDown(KeyCode.Q))
//        {
//            SetAnimatorState(battleStanceHash);
//        }
//        else if (Input.GetKeyDown(KeyCode.E))
//        {
//            SetAnimatorState(biteHash);
//        }
//        else if (Input.GetKeyDown(KeyCode.R))
//        {
//            SetAnimatorState(drakarisHash);
//        }
//        else if (Input.GetKeyDown(KeyCode.T))
//        {
//            SetAnimatorState(flyingFWDHash);
//        }
//        else if (Input.GetKeyDown(KeyCode.Y))
//        {
//            SetAnimatorState(flyingAttackHash);
//        }
//        else if (Input.GetKeyDown(KeyCode.U))
//        {
//            SetAnimatorState(hoverHash);
//        }
//        else if (Input.GetKeyDown(KeyCode.I))
//        {
//            SetAnimatorState(landsHash);
//        }
//        else if (Input.GetKeyDown(KeyCode.O))
//        {
//            SetAnimatorState(takeOffHash);
//        }
//        else if (Input.GetKeyDown(KeyCode.P))
//        {
//            SetAnimatorState(idleSimpleHash);
//        }
//    }

//    private void SetAnimatorState(int stateHash)
//    {
//        anim.Play(stateHash);
//    }
//}
