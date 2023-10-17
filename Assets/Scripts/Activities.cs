using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activities : MonoBehaviour
{
    public TofuData tofuData;

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

    public void DoAction(double health = 0, double affection = 0, double intelligence = 0, double fame = 0, double money=0)
    {
        if (tofuData.CheckAndApplyActivityChange(-1))
        {
            tofuData.UpdateStatus(health, affection, intelligence, fame);
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
