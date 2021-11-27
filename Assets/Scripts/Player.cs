using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
public float speed = 2.0f;
public float rotationSpeed = 100.0f;
public float jumpSpeed = 8.0f;
public float gravity = 20.0f;
public Animator animator;

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

void Update()
{
Actions actions = GetComponent<Actions>();
float translation = Input.GetAxis("Vertical")*speed;
float rotation = Input.GetAxis("Horizontal")*rotationSpeed;
translation*=Time.deltaTime;
rotation*=Time.deltaTime;
transform.Translate(0,0,translation);
transform.Rotate(0,rotation,0);
actions.Walk();
            if (Input.GetKey(KeyCode.Space))
            {
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
float translation1 = Input.GetAxis("Vertical")*3*speed;
float rotation1 = Input.GetAxis("Horizontal")*rotationSpeed;
translation1*=Time.deltaTime;
rotation1*=Time.deltaTime;
transform.Translate(0,0,translation1);
transform.Rotate(0,rotation1,0);
}
} 
}


