using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventSceneData", menuName = "ScriptableObject/EventSceneData", order = int.MaxValue)]
public class EventData : ScriptableObject
{
    [SerializeField]
    public string eventSceneName;

    [TextArea]
    public string[] dialogueTexts;

    [SerializeField]
    public Sprite[] backgroundImg;

    [SerializeField]
    public string nextSceneName;
}
