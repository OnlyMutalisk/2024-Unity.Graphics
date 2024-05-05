using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class Gun : MonoBehaviour
{
    public static string currentGun = "AR";
    protected virtual int catridge { get; set; }
    protected virtual int catridge_max { get; set; }
    protected virtual float reloadTime { get; set; }
    protected virtual float damage { get; set; }
    protected virtual float delay { get; set; }
    public GameObject bullet;
    public GameObject catridgeEffect;
    public GameObject fireEffect;
    protected bool isCorShootOn;
    protected bool isCorReloadOn;
    protected Transform pos;
    private AudioSource audioSource;

    // 생성 위치는 GameObject 와 같습니다.
    public void Start()
    {
        pos = gameObject.GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// <br>숫자키로 무기를 스위칭합니다.</br>
    /// <br>장전중이라면, 취소시킵니다.</br>
    /// </summary>
    public void Switch()
    {
        if (Input.GetKey(KeyCode.Alpha1) && currentGun != "AR")
        {
            audioSource.PlayOneShot(Resources.Load<AudioClip>("Sounds/Switch"));
            currentGun = "AR";
            audioSource.clip = Resources.Load<AudioClip>("Sounds/AR");
        }
        else if (Input.GetKey(KeyCode.Alpha2) && currentGun != "SR")
        {
            audioSource.PlayOneShot(Resources.Load<AudioClip>("Sounds/Switch"));
            currentGun = "SR";
            audioSource.clip = Resources.Load<AudioClip>("Sounds/SR");
        }
        else if (Input.GetKey(KeyCode.Alpha3) && currentGun != "SG")
        {
            audioSource.PlayOneShot(Resources.Load<AudioClip>("Sounds/Switch"));
            currentGun = "SG";
            audioSource.clip = Resources.Load<AudioClip>("Sounds/SG");
        }
    }

    /// <summary>
    /// <br>총알과 이펙트를 인스턴스화합니다.</br>
    /// <br>딜레이 구현을 위해, CorShoot 으로 사용합니다.</br>
    /// </summary>
    public void Shoot()
    {
        Instantiate<GameObject>(bullet, pos.position, pos.rotation);
        Instantiate<GameObject>(catridgeEffect, pos.position, pos.rotation);
        Instantiate<GameObject>(fireEffect, pos.position, pos.rotation);

        catridge--;
        audioSource.Play();

        Debug.Log(currentGun + catridge);
    }

    public IEnumerator CorShoot()
    {
        isCorShootOn = true;
        Shoot();
        yield return new WaitForSeconds(delay);
        isCorShootOn = false;
    }

    /// <summary>
    /// <br>탄창을 재충전합니다.</br>
    /// </summary>
    public IEnumerator CorReload()
    {
        isCorReloadOn = true;
        isCorShootOn = true;
        Debug.Log("장전중..");
        audioSource.PlayOneShot(Resources.Load<AudioClip>("Sounds/Reload"));
        yield return new WaitForSeconds(reloadTime);
        catridge = catridge_max;
        isCorReloadOn = false;
        isCorShootOn = false;
    }
}