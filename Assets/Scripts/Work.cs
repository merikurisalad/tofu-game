using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Work : Activities
{
    // Start is called before the first frame update
    private const double ACTION_UNIT_1ST = 1.0;
    private const double ACTION_UNIT_2ND = 1.1;
    private const double ACTION_UNIT_3RD = 1.2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CollectingRecycles()
    {
        System.Random rand = new System.Random();
        double[] possibleAmount = double int[] { 3.0, 4.0, 5.0 };
        double earnedMoney = possibleAmount[rand.Next(0, 2)];
        base.DoAction(affection=-(ACTION_UNIT_1ST*0.5), intelligence=(ACTION_UNIT_1ST*0.5), money=earnedMoney);
    }
}
