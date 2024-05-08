using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject deathPanel;
    public static float HP;
    private bool isDeath;

    private void Start()
    {
        isDeath = false;
        HP = GameManager.HP_char;
    }

    private void Update()
    {
        if (HP <= 0 && isDeath == false) { Death(); }
    }

    private void Death()
    {
        isDeath = true;
        deathPanel.SetActive(true);
        UpdateHighScore();
    }

    /// <summary>
    /// 최고기록을 갱신합니다.
    /// </summary>
    private void UpdateHighScore()
    {
        if (UI.score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", UI.score);
        }
    }
}
