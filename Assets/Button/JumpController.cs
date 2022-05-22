using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public Rigidbody2D rbody2D;

    private float jumpForce = 700f;

    private bool isGround;

    void Start()
    {
        isGround = true;
    }

    public void OnClick()
    {
        if (isGround == true)
        {
            this.rbody2D.AddForce(transform.up * jumpForce);
            isGround = false;
            Debug.Log("false");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("true");
            isGround = true;
        }
    }
}