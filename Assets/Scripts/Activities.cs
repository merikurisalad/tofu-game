using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activities : MonoBehaviour
{
    private TofuData tofuData;

    public Activities(TofuData currentTofu)
    {
        tofuData = currentTofu;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DoAction(int health = 0, int affection = 0, int intelligence = 0, int charm = 0, int reputation = 0, int money=0)
    {
        if (tofuData.CheckAndApplyActivityChange(-1))
        {
            tofuData.UpdateStatus(health, affection, intelligence, charm, reputation);
            tofuData.UpdateMoney(money);
            if (tofuData.availableActivities == 0)
            {
                tofuData.UpdateDaysPlayed();
            }
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
