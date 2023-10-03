using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutdoorActivities : Activities
{

    private const double ACTION_UNIT_1ST = 1.0;
    private const double ACTION_UNIT_2ND = 1.1;
    private const double ACTION_UNIT_3RD = 1.2;

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
        base.DoAction(health=ACTION_UNIT*0.5, affection=ACTION_UNIT*0.5);
    }
}
