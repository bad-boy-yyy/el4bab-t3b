using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Player variables
    public float playerSpeed = 7f;


    // Private refrences
    Rigidbody2D rb;
    [SerializeField] Vector2 moveDirection;
    float Horizontal;
    float Vertical;
    

    #region Set as Singleton

    public static PlayerMovement Instance;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    #endregion

    public void Start()
    {
        #region Set the rigidbody
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        #endregion
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        moveDirection = new Vector2(Horizontal * playerSpeed, Vertical * playerSpeed);
        

        //Move the player
        rb.velocity = moveDirection;
    }

}
