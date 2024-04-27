using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class SR : Gun
{
    protected override int catridge { get; set; } = GameManager.catridge_SR;
    protected override int catridge_max { get; set; } = GameManager.catridge_max_SR;
    protected override int reloadTime { get; set; } = GameManager.reloadTime_SR;
    protected override float damage { get; set; } = GameManager.damage_SR;
    protected override float delay { get; set; } = GameManager.delay_SR;
    public GameObject BulletEffect;

    public void Update()
    {
        if (currentGun == this.GetType().Name)
        {
            // 사격 감지, SR 은 추가 이펙트가 생성됩니다.
            if (Input.GetButton("Fire1") && isCorShootOn == false)
            {
                Instantiate<GameObject>(BulletEffect, pos.position, pos.rotation);
                StartCoroutine(CorShoot());
            }

            // 장전 감지
            if (Input.GetKeyDown(KeyCode.R) && isCorReloadOn == false)
            {
                StartCoroutine(CorReload());
            }

            // 스위칭 감지
            Switch();
        }
    }
}
