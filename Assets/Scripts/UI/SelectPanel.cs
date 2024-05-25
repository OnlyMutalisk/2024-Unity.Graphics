using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UI;

public class SelectPanel : MonoBehaviour
{
    // UI 요소를 연결합니다.
    public GameObject UpgradePanel;
    public Button btn;
    public Image image;
    public TextMeshProUGUI text_head;
    public TextMeshProUGUI text_body;

    // 강화할 스크립트 인스턴스를 연결합니다.
    public AR ar;
    public SR sr;
    public SG sg;
    public Character character;

    // 클래스 변수 입니다.
    private static List<int> rndList = new List<int>();
    private static int panelCount;

    /// <summary>
    /// <br>Resources/Images/Upgrade 에서 랜덤으로 스프라이트를 선택한 뒤</br>
    /// <br>그에 따라 업그레이드 함수와 UI 를 선택합니다.</br>
    /// <br>즉, 스프라이트 이름과 함수 이름은 바뀌어선 안됩니다 !</br>
    /// </summary>
    public void Init()
    {
        Time.timeScale = 0;
        Sprite[] sprites = Resources.LoadAll<Sprite>("Images/Upgrade");

        // 업그레이드가 서로 겹치지 않게 보장합니다.
        int rnd = Random.Range(0, sprites.Length);
        while (rndList.Contains(rnd) == true)
        {
            if (sprites.Length < panelCount) { break; }
            rnd = Random.Range(0, sprites.Length);
        }
        rndList.Add(rnd);
        Sprite sprite = sprites[rnd];

        // 리플렉션으로 게임 매니저에서 스프라이트 이름에 해당하는 텍스트를 가져옵니다.
        image.sprite = sprite;
        string a = sprite.name + "_text_head";
        text_head.text = typeof(GameManager).GetField(a, BindingFlags.Static | BindingFlags.Public).GetValue(null) as string;
        text_head.text = typeof(GameManager).GetField(sprite.name + "_text_head", BindingFlags.Static | BindingFlags.Public).GetValue(null) as string;
        text_body.text = typeof(GameManager).GetField(sprite.name + "_text_body", BindingFlags.Static | BindingFlags.Public).GetValue(null) as string;

        // 리플렉션으로 스프라이트 이름과 같은 핸들링 함수 실행
        MethodInfo method = GetType().GetMethod(sprite.name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        btn.onClick.AddListener(() => method.Invoke(this, null));
    }

    /// <summary>
    /// AR 의 데미지가 N % 강해집니다.
    /// </summary>
    public void Upgrade_AR_Damage()
    {
        ar.damage *= GameManager.Upgrade_AR_Damage_multiplier;
        Time.timeScale = 1;
    }

    /// <summary>
    /// SR 의 데미지가 N % 강해집니다.
    /// </summary>
    public void Upgrade_SR_Damage()
    {
        sr.damage *= GameManager.Upgrade_SR_Damage_multiplier;
        Time.timeScale = 1;
    }

    /// <summary>
    /// SG 의 데미지가 N % 강해집니다.
    /// </summary>
    public void Upgrade_SG_Damage()
    {
        sg.damage *= GameManager.Upgrade_SG_Damage_multiplier;
        Time.timeScale = 1;
    }

    /// <summary>
    /// AR 의 탄창 수가 N 발 많아집니다.
    /// </summary>
    public void Upgrade_AR_Cartridge()
    {
        ar.cartridge_max += GameManager.Upgrade_AR_Cartridge_add;
        Time.timeScale = 1;
    }

    /// <summary>
    /// AR 의 탄창 수가 N 발 많아집니다.
    /// </summary>
    public void Upgrade_SR_Cartridge()
    {
        sr.cartridge_max += GameManager.Upgrade_SR_Cartridge_add;
        Time.timeScale = 1;
    }

    /// <summary>
    /// AR 의 탄창 수가 N 발 많아집니다.
    /// </summary>
    public void Upgrade_SG_Cartridge()
    {
        sg.cartridge_max += GameManager.Upgrade_SG_Cartridge_add;
        Time.timeScale = 1;
    }

    public void Awake()
    {
        panelCount++;
    }

    private void OnDisable()
    {
        rndList.Clear();
    }
}
