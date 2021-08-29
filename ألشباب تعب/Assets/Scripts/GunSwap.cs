using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwap : MonoBehaviour
{
    
    public int currentWeapon;
    public Transform[] weapons;
    
    int selectedGun;

    public void Start()
    {




    }
    private void Update()
    {
      
           
          

                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
              
                    changeWeapon(0);
                   
                }

                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    
                    changeWeapon (1);
                    
                }

                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                   
                    changeWeapon (2);
                  
                }
                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                   
                    changeWeapon (3);
                    
                }
                if (Input.GetKeyDown(KeyCode.Alpha5))
                {

                    changeWeapon (4);
                }
                if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    
                    changeWeapon (5);
                    
                }
                if (Input.GetKeyDown(KeyCode.Alpha7))
                {
                    
                    changeWeapon (6);
                    
                }
                if (Input.GetKeyDown(KeyCode.Alpha8))
                {
                    
                    changeWeapon (7);
                    
                }
                if (Input.GetKeyDown(KeyCode.Alpha9))
                {
                    
                    changeWeapon (8);
                    
                }  
              
             
               
                }


        
 


    
    public void changeWeapon(int num)
    {


        currentWeapon = num;
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == num)
                weapons[i].gameObject.SetActive(true);
            else
                weapons[i].gameObject.SetActive(false);
        }


    }
   

}
