using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterAnimation : MonoBehaviour
{
    public static Transform trans;
    public Animator anim;

    void Update()
    {
        trans = gameObject.transform;

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
