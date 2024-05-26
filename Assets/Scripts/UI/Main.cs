using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public void btnExit()
    {
        Application.Quit();
    }

    public void btnStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Play");
    }
}
