using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OptionManager : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider sfxSlider;
    public Button engButton;
    public Button korButton;
    public Button vibrationOnButton;
    public Button vibrationOffButton;
    public Button collection;
    public Button contactUs;
    public GameObject contactPanel;
    private bool isConatctPanelActive;


    // Start is called before the first frame update
    void Start()
    {
        LoadSetting();

        isConatctPanelActive = false;
        contactPanel.SetActive(false);

        contactUs.onClick.AddListener(ToggleConatactPanel);
    }

    void ToggleConatactPanel()
    {
        contactPanel.SetActive(!isConatctPanelActive);
        isConatctPanelActive = !isConatctPanelActive;
    }

    void LoadSetting()
    {
        if (PlayerPrefs.HasKey("BGMVolume"))
        {
            bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        }

        if (PlayerPrefs.HasKey("Language"))
        {
            string language = PlayerPrefs.GetString("Language");
            if (language == "ENG")
            {
                SetLanguageToEnglish();
            }
            else if (language == "KOR")
            {
              //  SetLanguageToKorean();
            }
        }

        if (PlayerPrefs.HasKey("Vibration"))
        {
            bool isVibrationOn = PlayerPrefs.GetInt("Vibration") == 1;
            if (isVibrationOn)
            {
             //   SetVibrationOn();
            }
            else
            {
             //   SetVibrationOff();
            }
        }

    }

    public void InitializeDefaultSettings()
    {
        if (!PlayerPrefs.HasKey("BGMVolume"))
        {
            PlayerPrefs.SetFloat("BGMVolume", 0.5f);
        }

        if (!PlayerPrefs.HasKey("SFXVolume"))
        {
            PlayerPrefs.SetFloat("SFXVolume", 0.5f);
        }

        if (!PlayerPrefs.HasKey("Language"))
        {
            PlayerPrefs.SetString("Language", "ENG");
        }

        if (!PlayerPrefs.HasKey("Vibration"))
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }
    }

    public void SetBGMVolume(float volume)
    {
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void SetLanguageToEnglish()
    {
        PlayerPrefs.SetString("Language", "ENG");
        //engButton.GetComponent<Image>
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: MOUSE click or Touch 
        if (Input.GetMouseButtonDown(0) && isConatctPanelActive)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                isConatctPanelActive = false;
                contactPanel.SetActive(false);
            }
        }

    }
}
