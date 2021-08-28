using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float pcSpeed;

    public LayerMask canJumpLayer;

    public float jumpForce;

    private Rigidbody2D rb;

    private Vector2 myPos;
    public Camera cam;
    public Transform camPivot;
    public Transform cameraFollow;
    public float cameraSmoothness;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        
    }

    void FixedUpdate()
    {
       
    }

    void Update()
    {
        PCController();
        PlayerLook();
    }

    private void LateUpdate()
    {
        CameraFollow();
    }

    private void PCController()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 move = new Vector2(hor * pcSpeed, ver * pcSpeed);

        transform.position += move * Time.deltaTime;

        //rb.velocity = move * Time.deltaTime;
    }

    private void PlayerLook()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.z));

        Vector2 offset = mousePos - (Vector2)transform.position;

        offset.Normalize();

        float rotationz = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotationz);
    }

    private void CameraFollow()
    {
        //cam.transform.position = Vector3.Lerp(cam.transform.position, transform.position, 8 * Time.deltaTime);
        //cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -10);
        cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(cameraFollow.position.x, cameraFollow.position.y,-10), cameraSmoothness * Time.deltaTime);
    }
}
