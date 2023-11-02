using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActWorkManager : MonoBehaviour
{
    public GameObject workUI;
    public GameObject adventureUI;
    public string gameplaySceneName = "GamePlayScene";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchToGamePlayScene()
    {
        SceneManager.LoadScene(gameplaySceneName);
    }

    public void ShowWorkUI()
    {
        workUI.SetActive(true);
        adventureUI.SetActive(false);
    }

    public void ShowAdventureUI()
    {
        workUI.SetActive(false);
        adventureUI.SetActive(true);
    }
}
