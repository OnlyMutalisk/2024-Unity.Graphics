using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Dog : Mob
{
    protected override float attackDistance { get; set; } = GameManager.attackDistance_dog;
    protected override float speed { get; set; } = GameManager.speed_dog;
    protected override float HP { get; set; } = GameManager.HP_dog;
    protected override float damage { get; set; } = GameManager.damage_dog;
    protected override int score { get; set; } = GameManager.score_dog;
}
