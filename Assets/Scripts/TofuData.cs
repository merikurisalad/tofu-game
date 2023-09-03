using UnityEngine;
using System;


public class TofuData : MonoBehaviour
{
    public Status status = new Status();
    public int money = 50; // INITIAL AMOUNT COULD BE CHANGED
    public int maxActivitiesInDay = 10; // arbitrary
    public int availableActivities = maxActivitiesInDay;
    public int today = DateTime.UtcNow.Day;

    // Start is called before the first frame update
    void Start()
    {

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

    public Bool CheckAndApplyActivityChange(int change)
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
