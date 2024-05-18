using UnityEngine;

public class AR : Gun
{
    public override int cartridge { get; set; } = GameManager.cartridge_AR;
    public override int cartridge_max { get; set; } = GameManager.cartridge_max_AR;
    public override float reloadTime { get; set; } = GameManager.reloadTime_AR;
    public override float damage { get; set; } = GameManager.damage_AR;
    public override float delay { get; set; } = GameManager.delay_AR;

    public void Update()
    {
        if (currentGun == this.GetType().Name)
        {
            UI.Cartridge = cartridge;

            // 사격 감지
            if (Input.GetButton("Fire1") && isCorShootOn == false && isCorReloadOn == false && cartridge > 0)
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