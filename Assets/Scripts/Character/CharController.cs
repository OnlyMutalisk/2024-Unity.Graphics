using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    private float speed = GameManager.speed_char;
    private float jumpPower = GameManager.jumpPower_char;
    private float sensitivity = GameManager.sensitive;
    private float moveFB, moveLR;
    private float rotX, rotY;
    private bool isJump = false;
    private bool isTop = false;
    private float gravity = 9.8f;
    public CharacterController character;
    public Rigidbody rigid;
    public GameObject cam;

    private void Start()
    {
        character = GetComponent<CharacterController>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY = Input.GetAxis("Mouse Y") * sensitivity;

        CameraRotation(cam, rotX, rotY);

        moveFB = Input.GetAxis("Horizontal") * speed;
        moveLR = Input.GetAxis("Vertical") * speed;

        Vector3 movement;

        if (Input.GetKeyDown(KeyCode.Space) == true && isJump == false && isTop == false) { isJump = true; }

        if (isJump == true)
        {
            movement = new Vector3(moveFB, jumpPower, moveLR);
            movement = transform.rotation * movement;
            jumpPower -= 0.1f;
            gravity = 0;

            // jumpPower 가 0 이 되는 시점이 점프의 정점 입니다.
            if (jumpPower <= 0)
            {
                jumpPower = GameManager.jumpPower_char;
                isJump = false;
                isTop = true;
            }
        }
        else
        {
            movement = new Vector3(moveFB, -gravity, moveLR);
            movement = transform.rotation * movement;

            // 점프의 정점에서, 중력을 조금씩 늘리며 내려옵니다.
            if (gravity < 9.8f) { gravity += 0.1f; }
            if(gravity > jumpPower * 1.3) { isTop = false; }
        }

        character.Move(movement * Time.deltaTime);
    }

    /// <summary>
    /// <br>카메라가 캐릭터를 따라 회전합니다.</br>
    /// </summary>
    private void CameraRotation(GameObject cam, float rotX, float rotY)
    {
        transform.Rotate(0, rotX * Time.deltaTime, 0);
        // cam.transform.Rotate (-rotY * Time.deltaTime, 0, 0);
    }
}
