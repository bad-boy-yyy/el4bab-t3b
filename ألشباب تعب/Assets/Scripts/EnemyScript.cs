using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyScript : MonoBehaviour
{
    [SerializeField] Transform player;
    public float damage;
    [SerializeField] float health;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask Enemy;
    
    public CharacterController2D controller;

    float horizontal;

    [SerializeField] float runSpeed;

    bool jump, m_isMovingRight, m_isMovingLeft,m_isJam,m_CanMove, m_isRayHit;

    private void Start()
    {
        m_CanMove = true;
    }


    void Update()
    {
        
        Debug.Log(m_CanMove);
        Debug.DrawRay(transform.position + new Vector3(0.5f, -0.4f),Vector3.right);
        MyInput();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        
        if (m_isMovingRight)
        {
            RaycastHit2D hit;
            if (Physics2D.Raycast(transform.position, transform.right, 1.2f, groundLayer))
            {
                if(Physics2D.Raycast(transform.position + new Vector3(0,1,0),transform.right,1.2f,groundLayer))
                {

                } else
                {
                  /*  m_CanMove = false;
                    horizontal = 0;
                    m_isRayHit = (Physics2D.Raycast(transform.position + new Vector3(0.5f, -0.4f), transform.right, 1, groundLayer));
                    */
                    
                    jump = true;
                   
                    
                } 
                

            }
            if (Physics2D.Raycast(transform.position + new Vector3(0.51f,0,0), transform.right, 0.5f, Enemy))
            {

            m_isJam = true;

            } else
            {
                m_isJam = false;
            }
        } else if (m_isMovingLeft)
        {
            if (Physics2D.Raycast(transform.position, -transform.right, 1.2f, groundLayer))
            {
                if (Physics2D.Raycast(transform.position + new Vector3(0, 1, 0), -transform.right, 1.2f, groundLayer))
                {

                }
                else
                {
                    jump = true;
                }

            }
            if (Physics2D.Raycast(transform.position + new Vector3(-0.51f, 0, 0), -transform.right, 0.5f, Enemy))
            {

               m_isJam = true;

            } else
            {
               m_isJam = false;
               
            }
          
        }
        
        
        
    }
    private void FixedUpdate()
    {
        m_TookDamage = false;
        //m_isJam = false;
        Move();
    }
    void MyInput()
    {

        
        

            if (transform.position.x > player.transform.position.x)
            {
            m_isMovingLeft = true;
            m_isMovingRight = false;
            if (m_isJam)
            {
                horizontal = 0;
            }
            else
            {
               
                    horizontal = -1 * runSpeed;
               
            }
            }
            else if (transform.position.x < player.transform.position.x)
            {
            m_isMovingLeft = false;
            m_isMovingRight = true;
            if (m_isJam)
            {
                horizontal = 0;
            }
            else
            {
            
                    horizontal = 1 * runSpeed;
               
            }
            }
    }
    void Move()
    {
        controller.Move(horizontal * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= collision.GetComponent<BulletScript>().bulletDamage;
            collision.GetComponent<BulletScript>().CollidedWithSomething();
        }
    }
    
            bool m_TookDamage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !m_TookDamage)
            {
                Destroy(gameObject);
                HealthScript.Instance.TakeDamage(damage);
                m_TookDamage = true;
             }
    }

        

}
   
        
    


