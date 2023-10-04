using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Work : MonoBehaviour
{
    private static TofuData tofuData;
    // TODO: THINK MORE - how should we manage TofuData?
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CollectingRecycles()
    {
        if (tofuData.CheckAndApplyActivityChange(-1))
        {
            System.Random rand = new System.Random();
            int[] possibleAmount = new int[] { 5, 10, 15 };
            int earnedMoney = possibleAmount[rand.Next(0, 2)];
            tofuData.UpdateMoney(earnedMoney);
            tofuData.status.ChangeAffection(-1);
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
