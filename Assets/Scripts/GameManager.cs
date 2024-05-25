using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public static class GameManager
{
    #region Character

    // 캐릭터 설정값입니다.
    public static float sensitive = 100f; // 회전 민감도
    public static float speed_char = 10f;
    public static float jumpPower_char = 6f; // 로그 스케일로 점프력이 강해집니다.
    public static float HP_char = 100;

    // 레벨업 소요 경험치 입니다.
    public static List<float> exp_max = new List<float>
    {
        10,
        20,
        30,
        9999999999999
    };

    #endregion

    #region Guns

    // AR 설정값입니다.
    //public static float delay_AR = 0.22f;
    public static float delay_AR = 0.04f;
    public static int cartridge_AR = 30;
    public static int cartridge_max_AR = 30;
    public static float reloadTime_AR = 2;
    public static float damage_AR = 1;
    public static float damageLossPerDistance_AR = 0.1f; // 거리 비례 데미지 민감도

    // SR 설정값입니다.
    public static float delay_SR = 1.5f;
    public static int cartridge_SR = 7;
    public static int cartridge_max_SR = 7;
    public static float reloadTime_SR = 2;
    public static float damage_SR = 5;
    public static float damageLossPerDistance_SR = 0.1f;

    // SG 설정값입니다.
    public static float delay_SG = 0.8f;
    public static int cartridge_SG = 10;
    public static int cartridge_max_SG = 10;
    public static float reloadTime_SG = 2;
    public static float damage_SG = 0.5f;
    public static float damageLossPerDistance_SG = 0.5f;
    public static int extraBullet_SG = 40; // 산탄 수
    public static float fireAngle_SG = 40; // 산탄 각

    #endregion

    #region Mobs

    // 이동 관련 옵션은 각 프리팹의 NavMeshAgent 컴포넌트에서 설정합니다.
    // 공격 범위 옵션은 각 프리팹의 SphereCollider 컴포넌트의 Radius 로 조절합니다.

    // Spawner 설정값입니다.
    public static float delay_spawner = 0.1f;
    public static int population_limit = 200;
    public static float layLength = 50;
    public static float obstacleHeightLimit = 5;
    public static float radius = 200;

    // Spider 설정값입니다.
    public static float attackDistance_spider = 3f;
    public static float speed_spider = 3f;
    public static float HP_spider = 10;
    public static float damage_spider = 10;
    public static int score_spider = 1;
    public static int exp_spider = 5;

    // Dog 설정값입니다.
    public static float attackDistance_dog = 7f;
    public static float speed_dog = 10f;
    public static float HP_dog = 10;
    public static float damage_dog = 10;
    public static int score_dog = 2;
    public static int exp_dog = 5;

    #endregion

    #region Upgrade
    public static string Upgrade_AR_Damage_text_head = "AR";
    public static string Upgrade_AR_Damage_text_body = "Damage 10% ++";
    public static float Upgrade_AR_Damage_multiplier = 1.1f;
    
    public static string Upgrade_SR_Damage_text_head = "SR";
    public static string Upgrade_SR_Damage_text_body = "Damage 10% ++";
    public static float Upgrade_SR_Damage_multiplier = 1.1f;
    
    public static string Upgrade_SG_Damage_text_head = "SG";
    public static string Upgrade_SG_Damage_text_body = "Damage 10% ++";
    public static float Upgrade_SG_Damage_multiplier = 1.1f;

    public static string Upgrade_AR_Cartridge_text_head = "AR";
    public static string Upgrade_AR_Cartridge_text_body = "Cartridge + 3";
    public static int Upgrade_AR_Cartridge_add = 3;

    public static string Upgrade_SR_Cartridge_text_head = "SR";
    public static string Upgrade_SR_Cartridge_text_body = "Cartridge + 1";
    public static int Upgrade_SR_Cartridge_add = 1;

    public static string Upgrade_SG_Cartridge_text_head = "SG";
    public static string Upgrade_SG_Cartridge_text_body = "Cartridge + 2";
    public static int Upgrade_SG_Cartridge_add = 2;

    #endregion
}
