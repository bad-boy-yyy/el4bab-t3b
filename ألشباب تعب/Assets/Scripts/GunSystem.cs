using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake; 

public class GunSystem : MonoBehaviour
{
    [Header("Gun Variables")]
    public string GunName;
    public Sprite GunImage;
    public Transform gunBarrel;
    public float firerate,bulletSpeed, spread, recoil, ammo, maxAmmo, reloadTime,shakeRoughness,shakeMagnitude;
    public float damage;
    public GameObject bulletProjectile;
    public bool isAutomatic;



    public Text ammoText;

    // Graphics
    public ParticleSystem muzzleFlash;

    // Private refrences
    bool isReloading;
    bool ableToShoot;

    public InventoryScript inventory;
    public CraftingManager craftingManager;

    public void Start()
    {
        ableToShoot = true;
    }

    public void Update()
    {
        transform.SetAsLastSibling();
        UIControl();
        MyInput();
    }

    public void UIControl()
    {
        ammoText.text = ammo.ToString() + "/" + maxAmmo.ToString();
    }

    public void MyInput()
    {
        if (!inventory.inv && !ShopScript.Instance.isShopOpened && !craftingManager.isCrafting)
        {
            if (ammo < 1 && !isReloading)
            {
                Reload();
            }

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
    }
    public void Shoot()
    {
        if (ableToShoot && !isReloading && ammo > 0)
        {
            ableToShoot = false;
            ammo -= 1f;
            CameraShaker.Instance.ShakeOnce(shakeMagnitude, shakeRoughness, .1f, 1f);
            //GetComponentInParent.Instance..AddForce(-gunBarrel.transform.up * recoil, ForceMode2D.Impulse);
            GameObject bullet = Instantiate(bulletProjectile, gunBarrel.position, gunBarrel.rotation);

            bullet.transform.Rotate (new Vector3(0, 0, Random.Range(-spread, spread)));
            muzzleFlash.Play();
            
            bullet.GetComponent<BulletScript>().bulletDamage = damage;
            bullet.GetComponent<BulletScript>().bulletSpeed = bulletSpeed * 10;
            PlayerSystem.Instance.AddRecoil(recoil);
            
            
            Debug.Log("Pew Pew!");

            Invoke("ResetShot", firerate);
        }
    }
    public void ResetShot()
    {
        ableToShoot = true;
    }
    public void Reload()
    {
        isReloading = true;
        Invoke("EndReload", reloadTime);
    }
    public void EndReload()
    {
        isReloading = false;
        ammo = maxAmmo;
    }



}
