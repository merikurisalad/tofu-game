using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Manage frequency manager
public class FrequencyManager : MonoBehaviour
{
    public DateTime startDate;
    public int daysPlayed;
    public int lastFeed;
    public int lastWash;
    public DateTime lastAccess;

    public FrequencyManager()
    {
        startDate = DateTime.UtcNow;
        daysPlayed = 1;
        lastFeed = 0;
        lastWash = 0;
        lastAccess = DateTime.UtcNow;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: I set it in Update(), but I think once in a day could be enough for checking frequencies
    }

    public void UpdateLastFeed()
    {
        lastFeed = daysPlayed;
    }

    public void UpdateLastWash()
    {
        lastWash = daysPlayed;
    }

    public bool IsFeedFrequentEnough()
    {
        return (daysPlayed - lastFeed) <= 2;
    }

    public bool IsWashFrequentEnough()
    {
        return (daysPlayed - lastWash <= 2);
    }

    public bool IsAccessFrequentEnough()
    {
        DateTime now = DateTime.UtcNow;
        return (now.Day - lastAccess.Day <= 2);
    }
}
