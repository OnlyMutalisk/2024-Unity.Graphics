using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Slider HP;
    public Slider EXP;
    public TextMeshProUGUI level;
    public TextMeshProUGUI textCartridge;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textHighScore;
    public static int cartridge;
    public static int highScore;
    public static int score;

    public Image AR;
    public Sprite AR_On;
    public Sprite AR_Off;

    public Image SR;
    public Sprite SR_On;
    public Sprite SR_Off;
    
    public Image SG;
    public Sprite SG_On;
    public Sprite SG_Off;

    public GameObject MenuPanel;

    private void Start()
    {
        score = 0;
        Gun.currentGun = "AR";
    }

    private void Update()
    {
        HP.value = Character.HP / GameManager.HP_char;
        textCartridge.text = cartridge.ToString();
        textScore.text = score.ToString();
        highScore = PlayerPrefs.GetInt("HighScore");
        textHighScore.text = "High Score : " + highScore.ToString();
        level.text = "Level : " + (Character.level + 1).ToString();
        EXP.value = Character.exp / GameManager.exp_max[Character.level];
        ActiveGunImage();
    }

    /// <summary>
    /// <br>현재 사용중인 총의 이미지를 하이라이팅 합니다.</br>
    /// </summary>
    private void ActiveGunImage()
    {
        switch (Gun.currentGun)
        {
            case "AR":
                AR.sprite = AR_On;
                SR.sprite = SR_Off;
                SG.sprite = SG_Off;
                break;

            case "SR":
                SR.sprite = SR_On;
                AR.sprite = AR_Off;
                SG.sprite = SG_Off;
                break;
            
            case "SG":
                SG.sprite = SG_On;
                SR.sprite = SR_Off;
                AR.sprite = AR_Off;
                break;

            default:
                AR.sprite = AR_On;
                SG.sprite = SG_Off;
                SR.sprite = SR_Off;
                break;
        }
    }

    public void btnMenu()
    {
        if (Time.timeScale == 1) { Time.timeScale = 0; }
        else { Time.timeScale = 1; }

        if (MenuPanel.active == true) { MenuPanel.SetActive(false); }
        else { MenuPanel.SetActive(true); }
    }
}