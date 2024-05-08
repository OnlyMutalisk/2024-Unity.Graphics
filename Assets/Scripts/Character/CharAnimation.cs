using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class CharAnimation : MonoBehaviour
{
    public static Transform trans;
    public Animator anim;
    public AudioSource walkSound;

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
}
