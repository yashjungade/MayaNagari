using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
public CharacterController controller;
public float speed=2f;
public float rotationSpeed = 100.0f;
Vector3 velocity;
public Animator animator;
public float gravity= -9.81f;

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
        public void Jump () 
        {
		animator.SetBool ("Squat", false);
		animator.SetFloat ("Speed", 0f);
		animator.SetBool("Aiming", false);
		animator.SetTrigger ("Jump");
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


void Update()
{
Actions actions = GetComponent<Actions>();
if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey("w"))
{
float x=Input.GetAxis("Horizontal");
float z=Input.GetAxis("Vertical");
Vector3 move = transform.right*x + transform.forward*z;
controller.Move(move*speed*Time.deltaTime);
velocity.y+=gravity*Time.deltaTime;
controller.Move(velocity*Time.deltaTime);
actions.Walk();
}
            if(Input.anyKey==false)
            {
             actions.Stay();
             }
            if (Input.GetButton("Jump"))
            {
                actions.Jump();
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
if (((Input.GetKey(KeyCode.LeftShift)||Input.GetKey(KeyCode.RightShift)) && Input.GetKey(KeyCode.UpArrow))||((Input.GetKey(KeyCode.LeftShift)||Input.GetKey(KeyCode.RightShift)) && Input.GetKey("w")))
{   
actions.Run();
float x1=Input.GetAxis("Horizontal");
float z1=Input.GetAxis("Vertical");
Vector3 move1 = transform.right*x1 + transform.forward*z1;
controller.Move(move1*speed*2*Time.deltaTime);
velocity.y+=gravity*Time.deltaTime;
controller.Move(velocity*Time.deltaTime);
}
}
}
