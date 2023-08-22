using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSceneManager : MonoBehaviour
{
    public DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();

        dialogueManager.dialogues = new string[]
        {
            "Another peaceful day dawns upon our town...",
            "Wait, do you see that? A lone tofu sits abandoned.",
            "Oh no! It seems like this adorable tofu has been left behind by everyone.",
            "Little do they know, this isn’t just any tofu. It's special.",
            "If you decide to care for it, this tofu might just reveal some magical abilities!",
            "Are you ready to start on this delightful and mysterious journey with the tofu?",
        };

        dialogueManager.nextSceneName = "GamePlayScene";

        Debug.Log("Intro Dialogue Start");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
