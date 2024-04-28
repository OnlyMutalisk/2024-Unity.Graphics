using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static float HP = GameManager.HP_char;

    private void Update()
    {
        if (HP <= 0) { Death(); }
    }

    private void Death()
    {
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
