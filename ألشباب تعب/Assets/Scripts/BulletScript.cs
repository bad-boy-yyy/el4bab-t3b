using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int bulletDamage;
    public float bulletSpeed;
    public GameObject bulletImpact;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed * Time.deltaTime; 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject impact = Instantiate(bulletImpact, transform.position, Quaternion.identity);
        Destroy(impact, 1f);
        Debug.Log("sad");
        Destroy(gameObject);
    }
}
