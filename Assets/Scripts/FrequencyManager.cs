using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        CheckFeedFrequency();
        CheckWashFrequency();
        CheckAcccessFrequency();
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

    private void CheckFeedFrequency()
    {
        if (daysPlayed - lastFeed > 2)
        {
            tofuData.status.ChangeHealth(ACTION_UNIT * (-1));
        }
    }

    private void CheckWashFrequency()
    {
        if (daysPlayed - lastWash > 2)
        {
            tofuData.status.ChangeHealth(ACTION_UNIT * (-1));
        }
    }

    private void CheckAcccessFrequency()
    {
        DateTime now = DateTime.UtcNow;
        if (now.Day - lastAccess.Day > 2)
        {
            tofuData.status.ChangeAffection(ACTION_UNIT * (-1));
        }

        if (now.Day - lastAccess.Day == 1)
        {
            tofuData.status.ChangeAffection(ACTION_UNIT);
        }
    }
}
