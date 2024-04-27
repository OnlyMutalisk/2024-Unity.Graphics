using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    // 캐릭터 설정값입니다.
    public static float speed_char = 10f;
    public static float jumpPower_char = 10f;
    public static float HP_char = 100;

    // 총알은 N 초 후 소멸합니다.
    public static int bulletLife = 100;

    // 총알의 속도를 조절합니다.
    public static Single bulletPower = 30f;

    // AR 설정값입니다.
    public static float delay_AR = 0.2f;
    public static int catridge_AR  = 300;
    public static int catridge_max_AR = 30;
    public static int reloadTime_AR = 3;
    public static float damage_AR = 1;

    // SR 설정값입니다.
    public static float delay_SR = 1.5f;
    public static int catridge_SR = 300;
    public static int catridge_max_SR = 10;
    public static int reloadTime_SR = 3;
    public static float damage_SR = 3;

    // Spawner 설정값입니다.
    public static float delay_spawner = 3f;
    public static int population_limit = 3;

    // Spider 설정값입니다.
    public static float attackDistance_spider = 3f;
    public static float speed_spider = 2f;
    public static float HP_spider = 10;
    public static float damage_spider = 1;
    // 이동 관련 옵션은 프리팹의 NavMeshAgent 컴포넌트에서 설정합니다.
    // 공격 범위 옵션은 프리팹의 SphereCollider 컴포넌트의 Radius 로 조절합니다.
}
