using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventDataList", menuName = "ScriptableObject/EventDataList", order = int.MaxValue - 1)]
public class EventDataList : ScriptableObject
{
    // Start is called before the first frame update

    public List<EventData> eventDataList;
}
