using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public GameObject deathPanel;
    public GameObject upgradePanel;
    public SelectPanel[] selectPanels;
    private float HP_max;
    public static float HP;
    public static int level = 0;
    public static float exp = 0;
    private bool isDeath;

    private void Start()
    {
        isDeath = false;
        HP = GameManager.HP_char;
        level = 0;
        exp = 0;
    }

    private void Update()
    {
        if (HP <= 0 && isDeath == false) { Death(); }
        if (exp >= GameManager.exp_max[level]) { LevelUp(); }
    }

    private void Death()
    {
        Cursor.lockState = CursorLockMode.None;
        isDeath = true;
        deathPanel.SetActive(true);
        UpdateHighScore();
        Destroy(gameObject);
    }

    private void LevelUp()
    {
        Cursor.lockState = CursorLockMode.None;
        exp = 0;
        level++;
        upgradePanel.SetActive(true);
        foreach (var selectPanel in selectPanels)
        {
            selectPanel.Init();
        }
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
