using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSceneManager : MonoBehaviour // will be attached to EVENTSCENE
{
    public DialogueManager dialogueManager;
    public EventData currentEventData; //STATIC or find other way to access

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();

        if (currentEventData != null)
        {
            dialogueManager.SetDialogueData(currentEventData);
            Debug.Log("Event Dialogue Start");
        }
        else
        {
            Debug.LogError("Current EventData is not set!");
        }

        Debug.Log("Event Dialogue Start");

    }

}


//"Another peaceful day dawns upon our town...",
           // "Wait, do you see that? A lone tofu sits abandoned.",
          //  "Oh no! It seems like this adorable tofu has been left behind by everyone.",
//"Little do they know, this isn’t just any tofu. It's special.",
          //  "If you decide to care for it, this tofu might just reveal some magical abilities!",
          //  "Are you ready to start on this delightful and mysterious journey with the tofu?",