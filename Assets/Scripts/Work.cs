using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Work : Activities
{
    // Start is called before the first frame update
    private const int ACTION_UNIT = 1;
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
        int[] possibleAmount = new int[] { 5, 10, 15 };
        int earnedMoney = possibleAmount[rand.Next(0, 2)];
        base.DoAction(affection=-ACTION_UNIT, intelligence=ACTION_UNIT, money=earnedMoney);
    }
}
