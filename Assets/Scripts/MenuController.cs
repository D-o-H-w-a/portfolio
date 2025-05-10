using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    static MenuController instance;
    public static MenuController Instance => instance;

    public Button button;
    public GameObject rewardBar;
    public Text reGame;
    public Text reWard;
    public GameObject settingMenu;
    public GameObject startMenu;
    public GameObject gameMenu;
    private void Awake()
    {
        instance = this;
        gameMenu.SetActive(false);
        Time.timeScale = 0.0f;
    }

    public void ReTire()
    {
        button.gameObject.SetActive(true);
        rewardBar.SetActive(true);
        gameMenu.SetActive(false);
        reWard.text = "버틴 시각: " + (int)UIManager.Instance.startTime + "초";
        reGame.text = "재시작";
    }

    public void Regame()
    {
        rewardBar.SetActive(false);
        button.gameObject.SetActive(false);
        SceneManager.LoadScene("game");
        Time.timeScale = 1.0f;
    }

    public void OnSetting()
    {
        Time.timeScale = 0.0f;
        settingMenu.SetActive(true);
        gameMenu.SetActive(false);
    }

    public void OnStart()
    {
        Time.timeScale = 1.0f; 
        gameMenu.SetActive(true);
        startMenu.SetActive(false);
    }
}
