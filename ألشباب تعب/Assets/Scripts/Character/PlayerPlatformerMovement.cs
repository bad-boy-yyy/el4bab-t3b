using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerMovement : MonoBehaviour
{
    public CharacterController2D controller;         // Controller that BIG BRACK did.
                                                     // An empty line wtf do you expect?
    float horizontal;                                // Horizontal float for the Horizontal Axis.
    float vertical;                                  // The same thing in the upper comment but im too lazy to write it again so pls forgive me, actually its useless because its a platformer controller script but im so fucking lazy to remove this refrence.

    [SerializeField] float runSpeed;

    bool jump;


    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
    }
    private void FixedUpdate()
    {
        Move();
    }

    void MyInput() {

        horizontal = Input.GetAxisRaw("Horizontal") * runSpeed;
        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }



    }
   void Move()
    {
        controller.Move(horizontal * Time.fixedDeltaTime,false,jump);
        jump = false;
    }
}
