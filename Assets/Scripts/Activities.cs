using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activities : MonoBehaviour
{
    private TofuData tofuData;
    private const int ACTION_UNIT = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakingAWalk()
    {
        if (tofuData.CheckAndApplyActivityChange(-1))
        {
            tofuData.status.ChangeHealth(ACTION_UNIT);
            tofuData.status.ChangeAffection(ACTION_UNIT);
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
