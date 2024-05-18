using UnityEngine;

public class SR : Gun
{
    public override int cartridge { get; set; } = GameManager.cartridge_SR;
    public override int cartridge_max { get; set; } = GameManager.cartridge_max_SR;
    public override float reloadTime { get; set; } = GameManager.reloadTime_SR;
    public override float damage { get; set; } = GameManager.damage_SR;
    public override float delay { get; set; } = GameManager.delay_SR;
    public GameObject BulletEffect;

    public void Update()
    {
        if (currentGun == this.GetType().Name)
        {
            UI.Cartridge = cartridge;

            // 사격 감지, SR 은 추가 이펙트가 생성됩니다.
            if (Input.GetButton("Fire1") && isCorShootOn == false && isCorReloadOn == false && cartridge > 0)
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
