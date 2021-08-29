using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake; 

public class GunSystem : MonoBehaviour
{
    [Header("Gun Variables")]
    public string GunName;
    public Image GunImage;
    public Transform gunBarrel;
    public float firerate,bulletSpeed, spread, recoil, ammo, maxAmmo, reloadTime,shakeRoughness,shakeMagnitude;
    public int damage;
    public GameObject bulletProjectile;
    public bool isAutomatic;

    public CameraShaker shaker;

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
            CameraShaker.Instance.ShakeOnce(shakeMagnitude, shakeRoughness, .1f, 1f);
            //GetComponentInParent.Instance..AddForce(-gunBarrel.transform.up * recoil, ForceMode2D.Impulse);
            GameObject bullet = Instantiate(bulletProjectile, gunBarrel.position, gunBarrel.rotation);

            bullet.transform.Rotate (new Vector3(0, 0, Random.Range(-spread, spread)));
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
