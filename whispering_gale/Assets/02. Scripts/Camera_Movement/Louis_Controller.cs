using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Louis_Controller : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float gravity;
    public int quest11; // 0: not started, 1: started, 2: done

    private CharacterController controller;
    private Animator animator;

    private float rotation;
    private bool walking;
    private bool running;
    private bool back;
    private bool left;
    private bool right;

    private float x;
    private float z;

    [SerializeField]
    private DialogueTrigger BarrierD;

    void Awake()
    {

        rotation = 0.0f;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        walking = false;
        running = false;
        back = false;
        left = false;
        right = false;
    }
    

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal"); z = Input.GetAxis("Vertical");

        //walk
        if (z <= 0 && walking)
        {
            animator.SetBool("IsWalk", false);
            walking = false;
        }
        if (z > 0 && !walking) { 
            animator.SetBool("IsWalk", true);
            walking = true;
        }
            
        //back
        if (z < 0 && !back)
        {
            animator.SetBool("GoBack", true);
            back = true;
        }
        if (z>=0 && back)
        {
            animator.SetBool("GoBack", false);
            back = false;
        }

        //rotation
        if (walking)
        {
            transform.Rotate(0, speed * x, 0);
            if (left) {
                animator.SetBool("TurnLeft", false);
                left = false;}
            if (right){
                animator.SetBool("TurnRight", false);
                right = false;}
        }
        else
        {
            if (x > 0 && !right)
            {
                right = true;
                animator.SetBool("TurnRight", true);
            }
            if (x <= 0 && right)
            {
                right = false;
                animator.SetBool("TurnRight", false);
            }
            if (x < 0 && !left)
            {
                left = true;
                animator.SetBool("TurnLeft", true);
            }
            if (x >= 0 && left)
            {
                left = false;
                animator.SetBool("TurnLeft", false);
            }
        }

        //     }

        WalkAndRun();
    }

    void WalkAndRun()
    {
        bool shift = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift));
        if (walking && !running && shift)
        {
            running = true;
            animator.SetBool("IsRun", true);
        }
        if (running && (!shift || !walking)) {
            running = false;
            animator.SetBool("IsRun", false);
        }
        
    }

    public void Stop()
    {
        walking = false;
        running = false;
        back = false;
        left = false;
        right = false;
        animator.SetBool("IsRun", false);
        animator.SetBool("GoBack", false);
        animator.SetBool("IsWalk", false);
        animator.SetBool("TurnLeft", false);
        animator.SetBool("TurnRight", false);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collide");
        if (collision.gameObject.layer == 9)    // 9 is barrier
        {
            BarrierD.TriggerDialogue();
        }
    }
    

}
