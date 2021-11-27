using UnityEngine;
using System.Collections;

// This script moves the character controller forward
// and sideways based on the arrow keys.
// It also jumps when pressing space.
// Make sure to attach a character controller to the same game object.
// It is recommended that you make only one call to Move or SimpleMove per frame.

public class Controller : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    public Animator animator;
    private Vector3 moveDirection = Vector3.zero;

        public void Jump () 
        {
		animator.SetBool ("Squat", false);
		animator.SetFloat ("Speed", 0f);
		animator.SetBool("Aiming", false);
		animator.SetTrigger ("Jump");
	}
        public void Stay () {
		animator.SetBool("Aiming", false);
		animator.SetFloat ("Speed", 0f);
		}
        public void Walk () 
        {
		animator.SetBool("Aiming", true);
		animator.SetFloat ("Speed", 0.5f);
		animator.SetTrigger ("Walk");
	}  
        public void Run () {
		animator.SetBool("Aiming", false);
		animator.SetFloat ("Speed", 1f);
	}

	public void Attack () {
		Aiming ();
		animator.SetTrigger ("Attack");
	}


	public void Aiming () {
		animator.SetBool ("Squat", false);
		animator.SetFloat ("Speed", 0f);
		animator.SetBool("Aiming", true);
	}

	public void Sitting () {
		animator.SetBool ("Squat", !animator.GetBool("Squat"));
		animator.SetBool("Aiming", false);
	}


    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Actions actions = GetComponent<Actions>();
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;
            actions.Walk();
            

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                actions.Jump();
            }
            if(Input.anyKey==false)
            {
             actions.Stay();
             } 
            if (Input.GetKey(KeyCode.Mouse0))
            {   
                actions.Attack();
            } 
            if (Input.GetKey(KeyCode.Mouse1))
            {   
                actions.Aiming();
            } 
            if (Input.GetKey("c"))
            {   
                actions.Sitting();
            } 
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.UpArrow))
            {   
                actions.Run();
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= 3*speed;
            }
        }


        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
}


