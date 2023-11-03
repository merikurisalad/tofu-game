using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    private ArrayList basicActions;
    private ArrayList workActions;
    private ArrayList adventures;

    private const double ACTION_UNIT_1ST = 1.0;
    private const double ACTION_UNIT_2ND = 1.1;
    private const double ACTION_UNIT_3RD = 1.2;

    public ActionManager()
    {
        basicActions = new ArrayList();
        workActions = new ArrayList();
        adventures = new ArrayList();

        setInitialActions();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    ArrayList returnBasicActions()
    {
        return basicActions;
    }

    ArrayList returnWorkActions()
    {
        return workActions;
    }

    ArrayList returnAdventures()
    {
        return adventures;
    }

    void addBasicAction(Action action)
    {
        basicActions.Add(action);
    }

    void addworkAction(Action action)
    {
        workActions.Add(action);
    }

    void addAdventure(Action action)
    {
        adventures.Add(action);
    }

    public Action getActionByName(string actionName, string actionType)
    {
        ArrayList actionsToIterate;
        switch (actionType)
        {
            case "work":
                actionsToIterate = workActions;
                break;
            case "adventure":
                actionsToIterate = adventures;
                break;
            default:
                actionsToIterate = basicActions;
                break;
        }

        foreach (Action action in actionsToIterate)
        {
            if (action.checkName(actionName)) {
                return action;
            }
        }

        return null;
    }

    void setInitialActions()
    {
        Action feed = new Action("feed", ActionType.Basic);
        feed.setStatusAffect(health: ACTION_UNIT_1ST * 0.5, affection: ACTION_UNIT_1ST * 0.5);
        basicActions.Add(feed);

        Action wash = new Action("wash", ActionType.Basic);
        wash.setStatusAffect(health: ACTION_UNIT_1ST);
        basicActions.Add(wash);

        Action IGUpload = new Action("IGUpload", ActionType.Basic);
        IGUpload.setStatusAffect(fame: ACTION_UNIT_1ST);
        basicActions.Add(IGUpload);

        Action givingBean = new Action("giving bean", ActionType.Basic);
        givingBean.setStatusAffect(affection: ACTION_UNIT_1ST);
        basicActions.Add(givingBean);

        System.Random rand = new System.Random();
        double[] possibleAmount = { 3.0, 4.0, 5.0 };
        double earnedMoney = possibleAmount[rand.Next(0, 2)];
        Action collectingRecycles = new Action("collectingRecycles", ActionType.Work);
        collectingRecycles.setStatusAffect(affection: -(ACTION_UNIT_1ST * 0.5), intelligence: (ACTION_UNIT_1ST * 0.5), money: earnedMoney);
        workActions.Add(givingBean);

        Action takingAWalk = new Action("taking a walk", ActionType.Adventure);
        takingAWalk.setStatusAffect(health: ACTION_UNIT_1ST * 0.5, affection: ACTION_UNIT_1ST * 0.5);
        adventures.Add(givingBean);
    }

    public void addAction(Action action)
    {
        ArrayList typeToAdd;
        switch (action.getActionType())
        {
            case ActionType.Work:
                typeToAdd = workActions;
                break;
            case ActionType.Adventure:
                typeToAdd = adventures;
                break;
            default:
                typeToAdd = basicActions;
                break;
        }

        typeToAdd.Add(action);
    }
}