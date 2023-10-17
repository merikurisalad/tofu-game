using UnityEngine;
using System;
using System.Collections.Generic;

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
    // public int activitiesDoneInADay;
    public int maxActivitiesInDay = 10; // arbitrary
    public int availableActivities;
    public int today;
    public int remainingAttempts;
    public List<CollectionItem> collectionList = new List<CollectionItem>();
    public FrequencyManager frequencyManager;
    public int currentStage;



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
        // activitiesDoneInADay = 0;
        availableActivities = maxActivitiesInDay;
        remainingAttempts = 3;
        frequencyManager = new FrequencyManager();
        currentStage = 0;
    }

    public void ApplyLoadedData(TofuData loadedData)
    {
        status = loadedData.status;
        money = loadedData.money;
        // activitiesDoneInADay = loadedData.activitiesDoneInADay;
        availableActivities = loadedData.availableActivities;
        today = loadedData.today;
        remainingAttempts = loadedData.remainingAttempts;
        collectionList = loadedData.collectionList;
        frequencyManager = loadedData.frequencyManager;
        currentStage = loadedData.currentStage;
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

    public void UpdateDaysPlayed()
    {
        frequencyManager.daysPlayed += 1;
        availableActivities = maxActivitiesInDay;
        if (frequencyManager.daysPlayed % 15 == 0) {
            UpdateStage();
        }
    }

    public bool CheckAndApplyActivityChange(int change)
    {
        int activities = availableActivities + change;
        if (activities > 0)
        {
            availableActivities = activities;
            return true;
        } 
        else
        {
            return false;
        }
    }

    public void UpdateStage() {
        currentStage += 1;
        if (currentStage < 3) {
            // TODO: Lead to Stage Update Page and create new actions
        }
        else if (currentStage == 3) {
            // TODO: Lead To Ending
        }
    }
}
