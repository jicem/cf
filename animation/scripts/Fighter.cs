using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {
    
    private CharacterController controller;
    private Vector3 moveVector;
    private float verticalVelocity;

	
	public float movementSpeed = 0.01f;
	public float clockwise = 1000.0f;
	public float counterClockwise = -5.0f;
	public Rigidbody rigidbody;
    public Collider[] attackHitboxes;
	// Use this for initialization
	void Start () {
		//anim = GetComponent<Animator>();
		//rigidbody = GetComponent<Rigidbody>();
        //controller.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        

		if (Input.GetKey(KeyCode.D))
		{
			//anim.Play("standing_run_forward", -1, 0f);
			//anim.Play("standing_idle");
			rigidbody.position += Vector3.right * Time.deltaTime * movementSpeed;
		}
		else if (Input.GetKey(KeyCode.A))
		{
			//anim.Play("standing_run_back", -1, 1f);
			//anim.Play("standing_idle");
			rigidbody.position -= Vector3.right * Time.deltaTime * movementSpeed;
		}

	}

    private void launchAttack(Collider col)
    {
        
    }
}
