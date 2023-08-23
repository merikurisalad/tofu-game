using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSceneManager : MonoBehaviour
{
    public DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();

        dialogueManager.dialogues = new string[]
        {
            "One day, you came home to a shocking sight...",
            "The tofu was nowhere to be found, only a note was left behind.",
            "Feeling neglected and yearning for a better place, the tofu had run away from home.",
            "Would there be a chance to meet again? Only time will tell...",
            "Remember to always cherish your time with loved ones.",
            "--- GAME OVER ---",
        };

        dialogueManager.nextSceneName = "StartScene";

        Debug.Log("GameOver Dialogue Start");

    }

    // Update is called once per frame
    void Update()
    {

    }
}
