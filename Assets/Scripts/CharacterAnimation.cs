using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class CharacterAnimation : MonoBehaviour
{
    public static Transform trans;
    public Animator anim;
    public AudioSource walkSound;
    private float jumpPower = GameManager.jumpPower_char;
    private float jumpDelay = GameManager.jumpDelay_char;
    private bool isJump = false;

    private void Start()
    {
        walkSound.clip = Resources.Load<AudioClip>("Sounds/Walk");
    }

    private void Update()
    {
        trans = gameObject.transform;


        if (Input.GetButton("Jump"))
        {
            anim.SetBool("isMove", true);
            StartCoroutine(Jump());
        }
        if (Input.GetButton("Horizontal") | Input.GetButton("Vertical"))
        {
            anim.SetBool("isMove", true);
            if (walkSound.isPlaying == false) { walkSound.Play(); }
        }
        else
        {
            anim.SetBool("isMove", false);
        }

        if (Input.GetButton("Fire1"))
        {
            anim.SetBool("isShoot", true);
        }
        else
        {
            anim.SetBool("isShoot", false);
        }
    }

    private IEnumerator Jump()
    {
        if (isJump == false)
        {
            isJump = true;

            for (int i = 0; i < 1000; i++)
            {
                Vector3 target = gameObject.transform.position;
                target.y += jumpPower / 1000f;
                gameObject.transform.position = target;
                yield return new WaitForSeconds(0.0001f);
            }

            isJump = false;
        }
    }
}
