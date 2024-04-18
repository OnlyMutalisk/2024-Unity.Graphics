using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public Animator anim;

    void Update()
    {
        if (Input.GetButton("Horizontal") | Input.GetButton("Vertical") | Input.GetButton("Jump"))
        {
            anim.SetBool("isMove", true);
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
