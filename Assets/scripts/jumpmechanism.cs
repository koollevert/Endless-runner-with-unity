using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpmechanism : MonoBehaviour
{
    private float speed=30f;
    private float gravity=-20f;
    Vector3 moveVector;
    CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var vInput = Input.GetAxis("Vertical");

        if(characterController.isGrounded)
        {
            if(Input.GetButtonDown("Jump"))
            {
                moveVector.y=speed;
            }
            moveVector.y +=gravity*Time.deltaTime;
            characterController.Move(moveVector*Time.deltaTime);
        }
    }
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        characterController=GetComponent<CharacterController>();
    }

}
