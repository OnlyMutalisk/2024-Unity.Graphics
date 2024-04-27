using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class SR : Gun
{
    protected override int catridge { get; set; } = GameManager.catridge_SR;
    protected override int catridge_max { get; set; } = GameManager.catridge_max_SR;
    protected override int reloadTime { get; set; } = GameManager.reloadTime_SR;
    protected override float delay { get; set; } = GameManager.delay_SR;

    public void Update()
    {
        if (currentGun == "SR")
        {
            // 사격 감지
            if (Input.GetButton("Fire1") && isCorShootOn == false)
            {
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
