using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{

    public ResourcesScript resourcesScript;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.tag == "Wood")
        {
            resourcesScript.Wood++;
            Destroy(other.gameObject);
        }
        else if (other.collider.gameObject.tag == "Steal")
        {
            resourcesScript.Steel++;
            Destroy(other.gameObject);
        }
        else if (other.collider.gameObject.tag == "Rock")
        {
            resourcesScript.Rock++;
            Destroy(other.gameObject);
        }
    }

}
