using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int bulletLifeSeconds = GameManager.bulletLife;

    void Update()
    {
        //transform.Translate(Vector3.forward * GameManager.bulletPower * Time.deltaTime);

        bulletLifeSeconds--;

        if (bulletLifeSeconds <= 0)
        {
            Destroy(gameObject);
        }
    }
}
