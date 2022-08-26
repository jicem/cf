using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class animControl1 : MonoBehaviour {
    private CharacterController controller;
    private Vector3 moveVector;
    private float verticalVelocity;
    public Animator anim;
    public Rigidbody rigidbody;
    public float movementSpeed = 0.12f;
    public float clockwise = 1000.0f;
    public float counterClockwise = -5.0f;
    public BoxCollider collide;
    public Collider[] attackHitboxes;

    private float inputV;
    private bool jump, firstAttack, secondAttack, thirdAttack, block;
    private float time;

    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        time = 90.0f;
    }

    void Update()
    {
        time -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Joystick2Button0))
        {
            anim.SetBool("jump", true);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.Joystick2Button0))
        {
            anim.SetBool("jump", false);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0)
        {
            if (rigidbody.position.x >= 3.696001 || time >= 88f || collide.isTrigger == true)
            {
                rigidbody.velocity = new Vector3(0f, 0f, 0f);
            }
            else if(anim.GetBool("firstAttack") == false && anim.GetBool("secondAttack") == false && anim.GetBool("thirdAttack") == false && anim.GetBool("block") == false)
            {
                rigidbody.position += Vector3.right * Time.deltaTime * movementSpeed;
            }
            
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0)
        {
            if (rigidbody.position.x <= -1.514 || time >= 88f || collide.isTrigger == true)
            {
                rigidbody.velocity = new Vector3(0f, 0f, 0f);
            }
            else if(anim.GetBool("firstAttack") == false && anim.GetBool("secondAttack") == false && anim.GetBool("thirdAttack") == false && anim.GetBool("block") == false)
            {
                rigidbody.position -= Vector3.right * Time.deltaTime * movementSpeed;
            }
        }
        //Ignore the fact that this says inputV. I did this based off of a 3rd person animation set up but we only needed 1 input for the walk
        inputV = Input.GetAxis("Horizontal");
        anim.SetFloat("inputV", inputV);
        float moveX = inputV * 15f * Time.deltaTime;



        if (Input.GetKeyDown(KeyCode.LeftBracket) || Input.GetKeyDown(KeyCode.Joystick2Button1))
        {
            anim.SetBool("thirdAttack", true);
            LaunchAttack(attackHitboxes[0]);
        }
        else if (Input.GetKeyUp(KeyCode.LeftBracket) || Input.GetKeyUp(KeyCode.Joystick2Button1))
        {
            anim.SetBool("thirdAttack", false);
            LaunchAttack(attackHitboxes[0]);
        }
        else if (Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.Joystick2Button2))
        {
            anim.SetBool("firstAttack", true);
            LaunchAttack(attackHitboxes[0]);
        }
        else if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Joystick2Button3))
        {
            anim.SetBool("secondAttack", true);
            LaunchAttack(attackHitboxes[0]);
        }
        else if (Input.GetKeyUp(KeyCode.O) || Input.GetKeyUp(KeyCode.Joystick2Button2))
        {
            anim.SetBool("firstAttack", false);
        }
        else if (Input.GetKeyUp(KeyCode.P) || Input.GetKeyUp(KeyCode.Joystick2Button3))
        {
            anim.SetBool("secondAttack", false);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Joystick2Button4))
        {
            anim.SetBool("block", true);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.Joystick2Button4))
        {
            anim.SetBool("block", false);
        }

    }

    private void LaunchAttack(Collider col)
    {
        Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("HitBox"));
        foreach (Collider c in cols)
        {
            if (c.transform.root == transform)
            {
                continue;
            }
            Debug.Log(c.name);
            float damage = 0;
            switch(c.name)
            {
                case "Head":
                if (anim.GetBool("block") == true)
                {
                    damage = 3f;
                }
                else
                {
                    damage = 10;
                }
                //damage = 10;
                break;
                case "Torso":
                    if (anim.GetBool("block") == true)
                {
                    damage = 3f;
                }
                else
                {
                    damage = 8f;
                }
                break;

                default:
                    Debug.Log("Unable to identify body part");
                break;
            }
            c.SendMessageUpwards("TakeDamage", damage);
        }
    }
}
