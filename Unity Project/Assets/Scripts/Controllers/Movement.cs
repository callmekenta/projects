using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    public Transform cam;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDir;
    private Vector3 velocity;

    [SerializeField] public bool isGrounded;
    [SerializeField] private float gravity;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;


    [SerializeField] private float jumpHeight;
    //private float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private float pushForce;
	private Vector3 pushDir;
    private bool isStuned = false;
    private bool wasStuned = false;
    private bool canMove = true;

    private void Start(){
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update(){
        Move();
    }

    private void Move(){
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        if (canMove){
            
        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");

        moveDir = new Vector3(0f, 0f, moveZ);
        moveDir = transform.TransformDirection(moveDir);


        if(isGrounded){
            

            if(moveDir != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)){
                Walk();
            }
            else if(moveDir != Vector3.zero && Input.GetKey(KeyCode.LeftShift)){
                Run();
            }
            else if(moveDir == Vector3.zero){
                Idle();
            }
            
            if (Input.GetKeyDown(KeyCode.Space)){
                Jump();
            }

        }
        // can Air strafe
        moveDir *= moveSpeed;
        controller.Move(moveDir * Time.deltaTime);

        // Calculate Gravity
        velocity.y += gravity * Time.deltaTime;
        // Apply Gravity
        controller.Move(velocity * Time.deltaTime);
        }

    }

    private void Idle(){
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }
    private void Walk(){
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run(){
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }

    private void Jump(){
        if (isGrounded){
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

    }

    public void HitPlayer(Vector3 velocityF, float time)
	{
		//rb.velocity = velocityF;
        moveDir = velocityF;

		pushForce = velocityF.magnitude;
		pushDir = Vector3.Normalize(velocityF);
		StartCoroutine(Decrease(velocityF.magnitude, time));
	}

    private IEnumerator Decrease(float value, float duration)
	{
		if (isStuned){
            wasStuned = true;
            isStuned = true;
		    canMove = false;
        }

		float delta = 0;
		delta = value / duration;

		for (float t = 0; t < duration; t += Time.deltaTime)
		{
			yield return null;
            pushForce = pushForce - Time.deltaTime * delta;
            pushForce = pushForce < 0 ? 0 : pushForce;
			velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
		}

		if (wasStuned)
		{
			wasStuned = false;
		}
		else
		{
			isStuned = false;
			canMove = true;
		}
	}

}
