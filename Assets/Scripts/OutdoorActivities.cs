using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutdoorActivities : Activities
{

    private const int ACTION_UNIT = 1;

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
        base.DoAction(health=ACTION_UNIT, affection=ACTION_UNIT, charm=ACTION_UNIT);
    }
}
