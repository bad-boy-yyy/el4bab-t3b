﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float pcSpeed;

    public LayerMask canJumpLayer;

    public float jumpForce;

    private Rigidbody2D rb;

    private Vector2 myPos;
    private Camera cam;
    public float cameraSmoothness;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    void FixedUpdate()
    {
        PCController();
        CameraFollow();
    }

    private void PCController()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 move = new Vector2(hor * Time.deltaTime * pcSpeed, ver * Time.deltaTime * pcSpeed);

        rb.velocity = move;

        //transform.position += move;
    }

    private void CameraFollow()
    {
        myPos = new Vector3(transform.position.x, transform.position.y);
        cam.transform.position = Vector3.Lerp(cam.transform.position, myPos, cameraSmoothness * Time.deltaTime);
        cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -10);
    }
}
