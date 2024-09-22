using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerMovement
{
    public void Jump(Rigidbody rb, float jumpForce)
    {
        Debug.Log(jumpForce);
        Debug.Log(rb.velocity);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        Debug.Log("jump");
        Debug.Log(rb.velocity);
        
    }
    public void Move(Rigidbody rb, float movementSpeed)
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(xMove, rb.velocity.y, zMove) * movementSpeed;
    }
    public void Rotate(Rigidbody rb, float rotationSpeed)
    {

    }
}
