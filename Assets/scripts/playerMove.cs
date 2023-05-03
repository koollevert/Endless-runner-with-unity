using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
     private CharacterController controller;
    private float speed=100.0f;
    private Vector3 moveVector;
    public float speedIncreasePerSecond = 0.3f;
    private float verticalVelocity=0.0f;
    private float gravity=11.0f;
     private float animationDuration=2.8f;
     private bool isDead=false;
     private float startTime;
     private PauseResumeMenu pauseResumeMenu;

     /// Awake is called when the script instance is being loaded.
     private void Awake()
     {
        pauseResumeMenu=FindObjectOfType<PauseResumeMenu>();
     }

    //init
    void Start()
    {
       controller=GetComponent<CharacterController>(); 
       startTime=Time.time;
    }
    /// Update is called every frame, if the MonoBehaviour is enabled.
    void Update()
    {
        
        if(isDead)
        {
            return;
        }
        if(Time.time-startTime<animationDuration)
        {
            
            controller.Move(Vector3.forward*speed*Time.deltaTime);
            return;
        }
        moveVector=Vector3.zero;
        if(controller.isGrounded)
        {
            verticalVelocity= 0f;

        }
        else if(Input.GetButtonDown("Jump"))
        {
            moveVector.y=speed;
            //verticalVelocity -=gravity*Time.deltaTime;
        }
        else
        {
            verticalVelocity -=gravity*Time.deltaTime;
        }
        
        moveVector.x=Input.GetAxisRaw("Horizontal")* speed;
        moveVector.y=Input.GetAxis("Vertical")*speed;  

        if( Input.GetMouseButton(0)) //checks is the game is paused, if yes horizontal movement won't happen for the case of a pause button
        {
            //are we on touch on the right side?
            if(Input.mousePosition.x >Screen.width/2)
            {
                moveVector.x=speed;
            }else{
                moveVector.x=-speed;
            }
        }
        speed += speedIncreasePerSecond * Time.deltaTime;
        moveVector.y=verticalVelocity;
        moveVector.z=speed;
        controller.Move(moveVector * Time.deltaTime);
        
        
    }

    public void SetSpeed(float modifier)
    {
        speed=10.0f+modifier;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.z>transform.position.z+0.1f && hit.gameObject.tag=="Enemy")        {
            Death();
        }
        
    }

    private void Death()
    {
        isDead=true;
        GetComponent<ScoreScript>().onDeath();
    }
}