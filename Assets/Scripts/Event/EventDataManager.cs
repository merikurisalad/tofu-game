using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDataManager : MonoBehaviour
{
    // EVENT DATA MANAGEMENT

    public static EventDataManager Instance
    {
        get; private set;
    }

    public EventDataList eventDataListObject;
    private Dictionary<string, EventData> eventDataDict = new Dictionary<string, EventData>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
            return;
        }

        foreach (var eventData in eventDataListObject.eventDataList) 
        {
            eventDataDict[eventData.eventSceneName] = eventData;
        }
    }

    public EventData GetEventDataByName(string name)
    {
        if (eventDataDict.TryGetValue(name, out EventData eventData))
        {
            return eventData;
        }
        
        return null;
    }
}
