using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    // 캐릭터 설정값입니다.
    public static float speed_char = 10f;
    public static float jumpPower_char = 10f;

    // 총알은 N 초 후 소멸합니다.
    public static int bulletLife = 100;

    // 총알의 속도를 조절합니다.
    public static Single bulletPower = 30f;

    // AR 설정값입니다.
    public static float delay_AR = 0.2f;
    public static int catridge_AR  = 300;
    public static int catridge_max_AR = 30;
    public static int reloadTime_AR = 3;

    // SR 설정값입니다.
    public static float delay_SR = 1.5f;
    public static int catridge_SR = 300;
    public static int catridge_max_SR = 10;
    public static int reloadTime_SR = 3;

    // Spawner 설정값입니다.
    public static float delay_spawner = 3f;
    public static int population_limit = 3;

    // Mob 설정값입니다.
    public static float speed_mob = 10f;
}
