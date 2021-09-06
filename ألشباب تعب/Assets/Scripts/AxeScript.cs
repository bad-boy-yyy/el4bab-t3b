using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] LayerMask WoodLayer;

    Ray2D ray;
    RaycastHit2D hit;

    private void Update()
    {

        //Check if i hitting wood;

        if (Input.GetKey(KeyCode.C))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if(hit.collider != null)
            {
                Debug.Log("Hit " + hit.collider.name);
            }
                    }

    }
}
