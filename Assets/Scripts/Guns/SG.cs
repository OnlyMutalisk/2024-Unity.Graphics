using UnityEngine;

public class SG : Gun
{
    public override int catridge { get; set; } = GameManager.catridge_SG;
    public override int catridge_max { get; set; } = GameManager.catridge_max_SG;
    public override float reloadTime { get; set; } = GameManager.reloadTime_SG;
    public override float damage { get; set; } = GameManager.damage_SG;
    public override float delay { get; set; } = GameManager.delay_SG;
    private int extraBullet = GameManager.extraBullet_SG;
    private float fireAngle = GameManager.fireAngle_SG;
    public GameObject Bullet_SG;

    public void Update()
    {
        if (currentGun == this.GetType().Name)
        {
            UI.catridge = catridge;

            // 사격 감지, SG 는 추가 총알이 격발됩니다.
            if (Input.GetButton("Fire1") && isCorShootOn == false && isCorReloadOn == false && catridge > 0)
            {
                for (float f = -fireAngle / 2; f <= fireAngle / 2; f += fireAngle / extraBullet)
                {
                    Instantiate<GameObject>(Bullet_SG, pos.position, pos.rotation * Quaternion.Euler(0, f, 0));
                }

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