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
    public int money;
    // public int activitiesDoneInADay;
    public int maxActivitiesInDay = 10; // arbitrary
    public int availableActivities;
    public int today;
    public int remainingAttempts;
    public List<CollectionItem> collectionList = new List<CollectionItem>();



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
        today = 1;
        remainingAttempts = 3;

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

    public void UpdateMoney(int earnedMoney)
    {
        money += earnedMoney;
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
}
