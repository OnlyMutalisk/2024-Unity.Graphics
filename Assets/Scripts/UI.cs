using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Slider HP;
    public TextMeshProUGUI textCatridge;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textHighScore;
    public static int catridge;
    public static int score;
    public static int highScore;

    public Image AR;
    public Sprite AR_On;
    public Sprite AR_Off;
    public Image SR;
    public Sprite SR_On;
    public Sprite SR_Off;

    private void Update()
    {
        HP.value = Character.HP / GameManager.HP_char;
        textCatridge.text = catridge.ToString();
        textScore.text = score.ToString();
        highScore = PlayerPrefs.GetInt("HighScore");
        textHighScore.text = "High Score : " + highScore.ToString();
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
                break;

            case "SR":
                AR.sprite = AR_Off;
                SR.sprite = SR_On;
                break;

            default:
                AR.sprite = AR_On;
                SR.sprite = SR_Off;
                break;
        }
    }
}
