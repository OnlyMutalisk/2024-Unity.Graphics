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
    protected override int score { get; set; } = GameManager.score_spider;
}
