using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activities : MonoBehaviour
{
    private TofuData tofuData;
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
        tofuData.activitiesDoneInADay--;
        tofuData.status.ChangeHealth(2);
        tofuData.status.ChangeAffection(2);
    }
}
