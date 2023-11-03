using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class StageManager : MonoBehaviour
{
    private int currentState;
    private const double FIRST_THRESHOLD = 30;
    private const double SECOND_THRESHOLD = 70;
    private int inGameDaysPlayed;
    private ActionManager actionManager;

    private const double ACTION_UNIT_1ST = 1.0;
    private const double ACTION_UNIT_2ND = 1.1;
    private const double ACTION_UNIT_3RD = 1.2;

    // Start is called before the first frame update
    public StageManager()
    {
        currentState = 0;
        inGameDaysPlayed = 1;
        actionManager = new ActionManager();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateIngameDaysPlayed(int[] statusLevel)
    {
        inGameDaysPlayed += 1;
        // TODO: BAD ENDING when health gets 0
        //int health = statusLevel[0];
        //if (health == -1)
        //{
        //    triggerEnding();
        //}
        if (inGameDaysPlayed == FIRST_THRESHOLD)
        {
            currentState += 1;
            UpdateToSecondStage(statusLevel);
        }
        // else if
        else
        {
            if (inGameDaysPlayed == SECOND_THRESHOLD)
            {
                currentState += 1;
                UpdateToThirdStage(statusLevel);
            }
        }
        //else (inGameDaysPlayed == ENDING_THRESHOLD) {
        //    triggerEnding();
        //}
    }

    public void UpdateToSecondStage(int[] statusLevel)
    {
        // TODO: trigger event

        // TODO: Discuss - anything else to do for stage update?
        int health = statusLevel[0];
        int affection = statusLevel[1];
        int intelligence = statusLevel[2];
        int fame = statusLevel[3];

        // condition 1: BAD ENDING
        if (health == 0 && affection == 0)
        {
            // Trigger BAD ENDING: RUNAWAY
        }
        
        else
        {
            // common actions for stage 2
            Action reading = new Action("reading", ActionType.Basic);
            reading.setStatusAffect(intelligence: ACTION_UNIT_2ND);

            Action watchingNetflix = new Action("watching Netflix", ActionType.Basic);
            watchingNetflix.setStatusAffect(intelligence: ACTION_UNIT_2ND * 0.5, affection: ACTION_UNIT_2ND * 0.5);
            actionManager.addAction(watchingNetflix);

            Action goingTofuCafe = new Action("going tofu cafe", ActionType.Adventure);
            goingTofuCafe.setStatusAffect(affection: ACTION_UNIT_2ND * 0.7, fame: ACTION_UNIT_2ND * 0.3);
            actionManager.addAction(goingTofuCafe);

            Action exercising = new Action("exercise", ActionType.Basic);
            exercising.setStatusAffect(health: ACTION_UNIT_2ND);
            actionManager.addAction(exercising);

            // condition 1: IG influencer
            if (fame >= 1)
            {
                Action youtubeUpload = new Action("youtube upload", ActionType.Basic);
                youtubeUpload.setStatusAffect(fame: ACTION_UNIT_2ND);
                actionManager.addAction(youtubeUpload);
            }
            // condition 2: Happy Tofu
            if (affection >= 1)
            {
                Action goingOutTogether = new Action("going out Together", ActionType.Adventure);
                goingOutTogether.setStatusAffect(affection: ACTION_UNIT_2ND);
                actionManager.addAction(goingOutTogether);
            }
        }

    }

    public void UpdateToThirdStage(int[] statusLevel)
    {
        // TODO: trigger event
        int health = statusLevel[0];
        int affection = statusLevel[1];
        int intelligence = statusLevel[2];
        int fame = statusLevel[3];

        // condition 1: BAD ENDING
        if (fame > 1 && affection <= 0) 
        {
            // Trigger BAD ENDING: INDEPENDENT TOFU
        }

        else
        {
            // common actions for stage 3
            Action goingOut = new Action("going out with other tofu", ActionType.Adventure);
            goingOut.setStatusAffect(health: ACTION_UNIT_3RD * 0.5, fame: ACTION_UNIT_3RD * 0.5);


            // condition 1: intelligent tofu
            if (intelligence >= 1)
            {
                Action takingCourse = new Action("taking Corsera course", ActionType.Basic);
                takingCourse.setStatusAffect(intelligence: ACTION_UNIT_3RD);
                actionManager.addAction(takingCourse);
            }
            // condition 2: being family
            if (affection >= 1)
            {
                Action familyEvent = new Action("having family event", ActionType.Adventure);
                familyEvent.setStatusAffect(affection: ACTION_UNIT_3RD);
                actionManager.addAction(familyEvent);
            }

            // condition 3: popular influencer
            if (fame >= 1)
            {
                Action commercialActions = new Action("getting commercial/collaboration", ActionType.Work);
                System.Random rand = new System.Random();
                double[] possibleAmount = { 100.0, 150.0, 200.0 };
                double earnedMoney = possibleAmount[rand.Next(0, 2)];
                commercialActions.setStatusAffect(fame: ACTION_UNIT_3RD, money: earnedMoney);
                actionManager.addAction(commercialActions);
            }
        }
    }

    public void triggerEnding()
    {
        // TODO: ENDING
    }

    public Action getActionByName(string actionName, string actionType)
    {
        return actionManager.getActionByName(actionName, actionType);
    }
}
