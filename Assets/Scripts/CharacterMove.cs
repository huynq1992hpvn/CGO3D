using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private bool isGrounded;
    public Rigidbody myrb;
    public float speed = 10;
    public float boostspeed = 40;
    public float currentSpeed;
    public float jumpForce = 10;
        private void Start()
    {
        currentSpeed = speed;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentSpeed = boostspeed;
        }
        else
        {
            currentSpeed = speed;
        }
        float XLeftRight = Input.GetAxis("Horizontal");
        float zForwardbackward = Input.GetAxis("Vertical");
        transform.position += new Vector3(XLeftRight, 0, zForwardbackward) * currentSpeed * Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
            isGrounded = false;
        }
    }

    private void Jump()
    {
        myrb.velocity +=new Vector3(0,jumpForce,0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; 
        }
    }
}
