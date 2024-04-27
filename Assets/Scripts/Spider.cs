using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Spider : Mob
{
    protected override float attackDistance { get; set; } = GameManager.attackDistance_spider;
    protected override float speed { get; set; } = GameManager.speed_spider;
    protected override float HP { get; set; } = GameManager.HP_spider;
    protected override float damage { get; set; } = GameManager.damage_spider;

    private void Start()
    {
        // 나누는 값은 Animation Clip 의 Speed 값 입니다.
        animAttackLength = GetAnimationClipLength("Attack") / 3;
        animDeathLength = GetAnimationClipLength("Attack");
    }
}
