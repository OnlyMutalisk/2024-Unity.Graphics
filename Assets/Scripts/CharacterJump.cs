using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    private Rigidbody rigid;
    private int JumpPower = 1000000;
    private bool isJumping;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        isJumping = false;
    }

    private void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping )
            {
                isJumping = true;
                rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
