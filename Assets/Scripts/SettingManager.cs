using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public Slider bgSlider;
    public Text   bgSliderText;
    public int bgValue;

    public Slider effectSlider;
    public Text   effectSliderText;
    public int effectValue;
    public GameObject gameMenu;

    // Start is called before the first frame update
    void Start()
    {
        bgValue = Mathf.RoundToInt(bgSlider.value * 100);
        bgSliderText.text = bgValue.ToString();

        effectValue = Mathf.RoundToInt(effectSlider.value * 100);
        effectSliderText.text = effectValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {   
        if (Mathf.RoundToInt(bgSlider.value * 100) != bgValue) {
            bgValue = Mathf.RoundToInt(bgSlider.value * 100);
            bgSliderText.text = bgValue.ToString();
            AudioManager.Instance.audioSource.volume = bgSlider.value;
        }

        if (Mathf.RoundToInt(effectSlider.value * 100) != effectValue) {
            effectValue = Mathf.RoundToInt(effectSlider.value * 100);
            effectSliderText.text = effectValue.ToString();
            PlayerSound.Instance.audioSource.volume = effectSlider.value;
        }
    }

    public void Regame()
    {
        gameMenu.SetActive(true);
        Time.timeScale = 1.0f;
        this.gameObject.SetActive(false);
    }
}
