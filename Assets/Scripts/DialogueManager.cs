using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TypeEffect dialougue;
    public string[] dialogues;
    public string nextSceneName;

    public GameObject talkPanel;

    int dialogueIndex = 0;
    
    private void Update()
    {
        // Debug.Log("DialogueManager Update called!");

        if (Application.isEditor && Input.GetMouseButtonDown(0)) // Mouse Event
        {
            ShowNextDialogue();
            return;
        }

        if (Input.touchCount > 0) // Mobile Touch event
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                ShowNextDialogue();
            }
        }
    }

    public void ShowNextDialogue()
    {

        if (dialougue.isAnim)
        {
            dialougue.SetMsg("");
            return;
        }

        if (dialogueIndex < dialogues.Length)
        {
            Debug.Log(dialogues[dialogueIndex]);

            dialougue.SetMsg(dialogues[dialogueIndex]);
            dialogueIndex++;
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            talkPanel.SetActive(false);
            dialogueIndex = 0;
        }
    }

}
