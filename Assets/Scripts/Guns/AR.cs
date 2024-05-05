using UnityEngine;

public class AR : Gun
{
    protected override int catridge { get; set; } = GameManager.catridge_AR;
    protected override int catridge_max { get; set; } = GameManager.catridge_max_AR;
    protected override float reloadTime { get; set; } = GameManager.reloadTime_AR;
    protected override float damage { get; set; } = GameManager.damage_AR;
    protected override float delay { get; set; } = GameManager.delay_AR;

    public void Update()
    {
        if (currentGun == this.GetType().Name)
        {
            UI.catridge = catridge;

            // 사격 감지
            if (Input.GetButton("Fire1") && isCorShootOn == false && catridge > 0)
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