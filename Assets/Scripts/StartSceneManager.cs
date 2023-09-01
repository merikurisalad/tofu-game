using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartSceneManager : MonoBehaviour
{
    public Button startButton;
    public GameObject warningPanel;
    public AudioSource audioSource;
    public AudioClip buttonClickSound;

    // Start is called before the first frame update
    void Start()
    {
        if (DataManager.instance.IsSaveDataExists())
        {
            startButton.GetComponentInChildren<TextMeshProUGUI>().text = "Continue";
        }
        else
        {
            startButton.GetComponentInChildren<TextMeshProUGUI>().text = "Start Game";
        }

        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(PlayButtonClickSound);
        }

    }

    void PlayButtonClickSound()
    {
        audioSource.PlayOneShot(buttonClickSound); // TODO: FIX 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartGame()
    {
        DataManager.instance.LoadData();
        SceneManager.LoadScene("GamePlayScene");
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("OptionScene");
    }

    public void StartFromBeginning()
    {
        warningPanel.SetActive(true);

    }

    public void OnYesButtonPressed()
    {
        DataManager.instance.ClearData();
        SceneManager.LoadScene("IntroScene");
    }

    public void OnNoButtonPressed()
    {
        warningPanel.SetActive(false);
    }

    public void ExitGame()
    {
        if (Application.isEditor)
        {
            Debug.Log(" Stop Playing Game in Editor");
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }

    }
}
