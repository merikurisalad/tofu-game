using UnityEngine;
using System;
using System.Collections.Generic;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class TofuData
{
    public class CollectionItem // Where to locate?
    {
        public string itemName;
        public string description;
        public bool isCollected;
        public string itemImageName; // TODO: 
    }

    private static TofuData _instance;
    public static TofuData instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new TofuData();
            }
            return _instance;
        }
    }


    public Status status;
    public double money;
    public int maxActivitiesInDay = 10; // arbitrary
    public int availableActivities;
    public int today;
    public int remainingAttempts;
    public List<CollectionItem> collectionList = new List<CollectionItem>();
    public FrequencyManager frequencyManager;
    public StageManager stageManager;


    // Start is called before the first frame update
    private TofuData()
    {
        ResetData();
    }

    public void ResetData()
    {
        status = new Status();
        money = 50;
        // TODO: decide what to do with activities, max, etc.
        availableActivities = maxActivitiesInDay;
        remainingAttempts = 3;
        frequencyManager = new FrequencyManager();
        stageManager = new StageManager();
    }

    public void ApplyLoadedData(TofuData loadedData)
    {
        status = loadedData.status;
        money = loadedData.money;
        availableActivities = loadedData.availableActivities;
        today = loadedData.today;
        remainingAttempts = loadedData.remainingAttempts;
        collectionList = loadedData.collectionList;
        frequencyManager = loadedData.frequencyManager;
        stageManager = loadedData.stageManager;
    }
  
    // Update is called once per frame
    void Update()
    {
        // TODO: Can we set it to be called only once in a day?
        DateTime now = DateTime.UtcNow;
        if (now.Day != today)
        {
            today = now.Day;
            availableActivities = maxActivitiesInDay;
        }
    }

    public void UpdateMoney(double earnedMoney)
    {
        money += earnedMoney;
    }

    public void UpdateStatus(double health, double affection, double intelligence, double fame)
    {
        status.ChangeHealth(health);
        status.ChangeAffection(affection);
        status.ChangeIntelligence(intelligence);
        status.ChangeFame(fame);
    }

    public DateTime getLastAccess()
    {
        return frequencyManager.lastAccess;
    }

    public bool CheckAndApplyActivityChange(int change)
    {
        int activities = availableActivities + change;
        if (activities >= 0)
        {
            availableActivities = activities;
            return true;
        } 
        else
        {
            int[] statusLevel = status.ReturnStatusLevel();
            stageManager.updateIngameDaysPlayed(statusLevel);
            availableActivities = maxActivitiesInDay;
            return false;
        }
    }

    public void DoAction(string actionName, string actionType)
    {
        if (CheckAndApplyActivityChange(-1))
        {
            Action action = stageManager.getActionByName(actionName, actionType);
            if (action == null)
            {
                throw new Exception("Invalid Action");
            }
            Dictionary<string, double> statusChange = action.getStatusAffect();
            if (statusChange == null)
            {
                throw new Exception("Invalid Action");
            }
            double curr_h = statusChange["health"];
            double curr_a = statusChange["affection"];
            double curr_i = statusChange["intelligence"];
            double curr_f = statusChange["fame"];
            double curr_m = statusChange["money"];

            UpdateStatus(curr_h, curr_a, curr_i, curr_f);
            UpdateMoney(curr_m);
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
}
