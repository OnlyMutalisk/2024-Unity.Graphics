using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    // 캐릭터 설정값입니다.
    public static float speed_char = 10f;
    public static float jumpPower_char = 25f;
    public static float jumpDelay_char = 3f;
    public static float HP_char = 100;

    // AR 설정값입니다.
    public static float delay_AR = 0.22f;
    public static int catridge_AR  = 30;
    public static int catridge_max_AR = 30;
    public static float reloadTime_AR = 2;
    public static float damage_AR = 1;
    public static float damageLossPerDistance_AR = 0.1f; // 거리 비례 데미지 민감도

    // SR 설정값입니다.
    public static float delay_SR = 1.5f;
    public static int catridge_SR = 7;
    public static int catridge_max_SR = 7;
    public static float reloadTime_SR = 2;
    public static float damage_SR = 5;
    public static float damageLossPerDistance_SR = 0.1f;

    // SG 설정값입니다.
    public static float delay_SG = 0.8f;
    public static int catridge_SG = 10;
    public static int catridge_max_SG = 10;
    public static float reloadTime_SG = 2;
    public static float damage_SG = 0.5f;
    public static float damageLossPerDistance_SG = 0.5f;
    public static int extraBullet_SG = 40; // 산탄 수
    public static float fireAngle_SG = 40; // 산탄 각

    // Spawner 설정값입니다.
    public static float delay_spawner = 3f;
    public static int population_limit = 1;

    // Spider 설정값입니다.
    public static float attackDistance_spider = 3f;
    public static float speed_spider = 3f;
    public static float HP_spider = 10;
    public static float damage_spider = 10;
    public static int score_spider = 1;
    // 이동 관련 옵션은 각 프리팹의 NavMeshAgent 컴포넌트에서 설정합니다.
    // 공격 범위 옵션은 각 프리팹의 SphereCollider 컴포넌트의 Radius 로 조절합니다.
}
