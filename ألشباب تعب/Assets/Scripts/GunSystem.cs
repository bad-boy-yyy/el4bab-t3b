using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunSystem : MonoBehaviour
{
    [Header("Gun Variables")]
    public string GunName;
    public Image GunImage;
    public Transform gunBarrel;
    public float firerate,bulletSpeed, spread, recoil, ammo, maxAmmo, reloadTime;
    public int damage;
    public GameObject bulletProjectile;
    public bool isAutomatic;



    // Graphics
    public ParticleSystem muzzleFlash;

    // Private refrences
    bool ableToShoot;



    public void Start()
    {
        ableToShoot = true;
    }

    public void Update()
    {
        MyInput();
    }

    public void MyInput()
    {
        if (isAutomatic)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
            }
        }
        else
        {

            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }

        }
    }
    public void Shoot()
    {
        if (ableToShoot)
        {
            ableToShoot = false;

            GameObject bullet = Instantiate(bulletProjectile, gunBarrel.position, gunBarrel.rotation);
            muzzleFlash.Play();
            
            bullet.GetComponent<BulletScript>().bulletDamage = damage;
            bullet.GetComponent<BulletScript>().bulletSpeed = bulletSpeed * 10;
            
            
            Debug.Log("Pew Pew!");

            Invoke("ResetShot", firerate);
        }
    }
    public void ResetShot()
    {
        ableToShoot = true;
    }



}
