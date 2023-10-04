using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// TODO: CHECK WITH UI ON HOW ACTIONS ARE DONE -> MIGHT MOVE THE COMPONENT?
public class MainActions : MonoBehaviour
{
    public Button feed;
    public DateTime lastFeed;
    public Button wash;
    public DateTime lastWash;
    public Button IGupload;
    public Button givingBean;
    private static TofuData tofuData;
    private DateTime lastAccess;

    private const int ACTION_UNIT = 2;

    // Start is called before the first frame update
    void Start()
    {
        lastAccess = DateTime.UtcNow;
    }

    private void OnEnable()
    {
        //Register Button Events
        feed.onClick.AddListener(() => FeedCallBack());
        wash.onClick.AddListener(() => WashCallBack());
        IGupload.onClick.AddListener(() => IGUploadCallBack());
        givingBean.onClick.AddListener(() => GivingBeanCallBack());
    }

    private void FeedCallBack()
    {
        if (tofuData.CheckAndApplyActivityChange(-1))
        {
            tofuData.status.ChangeHealth(ACTION_UNIT);
            tofuData.status.ChangeAffection(ACTION_UNIT);
            lastFeed = DateTime.UtcNow;
        }
        else
        {
            SendMaxedOutActivity();
        }
    }

    private void WashCallBack()
    {
        if (tofuData.CheckAndApplyActivityChange(-1))
        {
            tofuData.status.ChangeHealth(ACTION_UNIT);
            tofuData.status.ChangeCharm(ACTION_UNIT);
            lastFeed = DateTime.UtcNow;
        }
        else
        {
            SendMaxedOutActivity();
        }
    }

    private void IGUploadCallBack()
    {
        if (tofuData.CheckAndApplyActivityChange(-1))
        {
            tofuData.status.ChangeReputation(ACTION_UNIT);
        }
        else
        {
            SendMaxedOutActivity();
        }
    }

    private void GivingBeanCallBack()
    {
        if (tofuData.CheckAndApplyActivityChange(-1))
        {
            tofuData.status.ChangeAffection(ACTION_UNIT);
            tofuData.status.ChangeCharm(ACTION_UNIT);
        }
        else
        {
            SendMaxedOutActivity();
        }
    }

    private void SendMaxedOutActivity()
    {
        // TODO: notify user that they have maxed out their available activities
    }
    
    // Update is called once per frame
    void Update()
    {
        CheckFeedFrequency();
        CheckWashFrequency();
        CheckAcccessFrequency();
        // TODO: I set it in Update(), but I think once in a day could be enough for checking frequencies
    }

    private void CheckFeedFrequency()
    {
        DateTime now = DateTime.UtcNow;
        if (now.Day - lastFeed.Day < 2)
        {
            tofuData.status.ChangeHealth(ACTION_UNIT * (-1));
        }
    }

    private void CheckWashFrequency()
    {
        DateTime now = DateTime.UtcNow;
        if (now.Day - lastWash.Day < 2)
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
