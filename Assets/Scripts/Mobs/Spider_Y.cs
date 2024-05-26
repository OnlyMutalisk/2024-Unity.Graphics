using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Spider_Y : Mob
{
    protected override float attackDistance { get; set; } = GameManager.attackDistance_spider_Y;
    protected override float speed { get; set; } = GameManager.speed_spider_Y;
    protected override float HP { get; set; } = GameManager.HP_spider_Y;
    protected override float damage { get; set; } = GameManager.damage_spider_Y;
    protected override int score { get; set; } = GameManager.score_spider_Y;
    protected override int exp { get; set; } = GameManager.exp_spider_Y;
}
