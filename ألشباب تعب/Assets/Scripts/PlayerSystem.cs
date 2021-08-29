using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{

    private Vector2 myPos;
    public Camera cam;
    public Transform camPivot;
    public Transform cameraFollow;
    public Transform gunHolder;
    public float cameraSmoothness;

    Vector2 moveDirection;

    public static PlayerSystem Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
  
   

    void Update()
    {
        
        PlayerLook();
    }

    private void LateUpdate()
    {
        CameraFollow();
    }

    

    private void PlayerLook()
    {
     
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(gunHolder.transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        gunHolder.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        float gH_angle = gunHolder.transform.localEulerAngles.z;
        
        if (gH_angle >= 0 && gH_angle < 180)
        {
            SpriteRenderer[] gunsSprites = gunHolder.GetComponentsInChildren<SpriteRenderer>();
            foreach(SpriteRenderer s in gunsSprites)
            {
                s.flipY = true;
            }
        } 
        else
        {
            SpriteRenderer[] gunsSprites = gunHolder.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer s in gunsSprites)
            {
                s.flipY = false;
            }

        }

    }

    private void CameraFollow()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(cameraFollow.position.x, cameraFollow.position.y,-10), cameraSmoothness * Time.deltaTime);
    }
}
