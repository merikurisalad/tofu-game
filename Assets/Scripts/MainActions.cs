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

    private const int ACTION_UNIT = 2;

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
        base.DoAction(health=ACTION_UNIT, affection=ACTION_UNIT);
        tofuData.frequencyManager.UpdateLastFeed();
    }

    private void Wash()
    {
        base.DoAction(health=ACTION_UNIT, charm=ACTION_UNIT);
        tofuData.frequencyManager.UpdateLastWash();
    }

    private void IGUpload()
    {
        base.DoAction(reputation=ACTION_UNIT);
    }

    private void GivingBean()
    {
        base.DoAction(affection=ACTION_UNIT, charm=ACTION_UNIT);
    }
    
    // Update is called once per frame
    void Update()
    {

    }
}
