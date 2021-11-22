using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public GameObject gameMenu;
    public GameObject setting;
    public void Replay()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("game");
    }
    public void OnRegame()
    {
        Time.timeScale = 1.0f;
        gameMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void OnSetting()
    {
        setting.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
