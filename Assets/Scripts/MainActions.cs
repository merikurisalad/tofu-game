using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// TODO: CHECK WITH UI ON HOW ACTIONS ARE DONE -> MIGHT MOVE THE COMPONENT?
public class MainActions : Activities
{
    public Button feed;
    public DateTime lastFeed;
    public Button wash;
    public DateTime lastWash;
    public Button IGupload;
    public Button givingBean;
    private DateTime lastAccess;

    private const double ACTION_UNIT_1ST = 1.0;
    private const double ACTION_UNIT_2ND = 1.1;
    private const double ACTION_UNIT_3RD = 1.2;

    // Start is called before the first frame update
    void Start()
    {
        lastAccess = DateTime.UtcNow;
    }

    private void OnEnable()
    {
        //Register Button Events
        feed.onClick.AddListener(() => Feed());
        wash.onClick.AddListener(() => Wash());
        IGupload.onClick.AddListener(() => IGUpload());
        givingBean.onClick.AddListener(() => GivingBean());
    }

    private void Feed()
    {
        base.DoAction(health=ACTION_UNIT_1ST*0.5, affection=ACTION_UNIT_1ST*0.5);
        tofuData.frequencyManager.UpdateLastFeed();
    }

    private void Wash()
    {
        base.DoAction(health=ACTION_UNIT_1ST);
        tofuData.frequencyManager.UpdateLastWash();
    }

    private void IGUpload()
    {
        base.DoAction(fame=ACTION_UNIT_1ST);
    }

    private void GivingBean()
    {
        base.DoAction(affection=ACTION_UNIT_1ST);
    }
    
    // Update is called once per frame
    void Update()
    {

    }
}
