using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform gunHolder;
    [SerializeField] float damage;
    [SerializeField] float health;
    // Start is called before the first frame update
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        
    }
    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log("انا خرمان");
        }
    }
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        
        
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            HealthScript.Instance.TakeDamage(damage);
        }
        if(collision.gameObject.tag == "Bullet")
        {
            health -= collision.gameObject.GetComponent<BulletScript>().bulletDamage;
        }
    }
    
}
