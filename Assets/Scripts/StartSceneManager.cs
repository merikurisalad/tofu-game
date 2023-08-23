using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartGame()
    {
        // Add logic to determin the user start from Beginning or not
        SceneManager.LoadScene("GamePlayScene");
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("OptionScene");
    }

    public void StartFromBeginning()
    {
        SceneManager.LoadScene("IntroScene");

    }
}
