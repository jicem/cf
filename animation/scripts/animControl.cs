using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class animControl : MonoBehaviour {
    private CharacterController controller;
    private Vector3 moveVector;
    private float verticalVelocity;
    public Animator anim;
    public Rigidbody rigidbody;
    public float movementSpeed = 0.12f;
    public float clockwise = 1000.0f;
    public float counterClockwise = -5.0f;
    public Collider[] attackHitboxes;
    public AudioClip swordSound;
    private AudioSource source;
    private float inputV;
    private bool jump, firstAttack, secondAttack, thirdAttack, block;
    private float time;

    public BoxCollider collide;


    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        time = 90.0f;
    }

    void Update()
    {
        time -= Time.deltaTime;

        if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal1") > 0)
        {
            if (rigidbody.position.x >= 3.696001 || time >= 88f || collide.isTrigger == true)
            {
                rigidbody.velocity = new Vector3(0f, 0f, 0f);
            }
            else if (anim.GetBool("firstAttack") == false && anim.GetBool("secondAttack") == false && anim.GetBool("thirdAttack") == false && anim.GetBool("block") == false)
            {
                rigidbody.position += Vector3.right * Time.deltaTime * movementSpeed;
            }
            
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal1") < 0)
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
        inputV = Input.GetAxis("Horizontal1");
        anim.SetFloat("inputV", inputV);
        float moveX = inputV * 15f * Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            anim.SetBool("thirdAttack", true);
            LaunchAttack(attackHitboxes[0]);
        }
        else if (Input.GetKeyUp(KeyCode.R) || Input.GetKeyUp(KeyCode.Joystick1Button1))
        {
            anim.SetBool("thirdAttack", false);
        } 
        else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            anim.SetBool("firstAttack", true);
            LaunchAttack(attackHitboxes[0]);
            source.PlayOneShot(swordSound, 1F);
        }
        else if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            anim.SetBool("secondAttack", true);
            LaunchAttack(attackHitboxes[0]);
        }
        else if(Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.Joystick1Button2))
        {
            anim.SetBool("firstAttack", false);
        }
        else if (Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.Joystick1Button3))
        {
            anim.SetBool("secondAttack", false);
        }
        else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            anim.SetBool("block", true);
        }
        else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.Joystick1Button4))
        {
            anim.SetBool("block", false);
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            anim.SetBool("jump", true);
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Joystick1Button0))
        {
            anim.SetBool("jump", false);
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
                    if(anim.GetBool("block") == true)
                    {
                        damage = 3f;
                    }else
                    {
                        damage = 10;
                    }
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
