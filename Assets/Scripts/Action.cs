using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionType
{
    Basic,
    Work,
    Adventure
}

public class Action : MonoBehaviour
{
    private ActionType actionType;
    private string actionName;
    private Dictionary<string, double> statusAffect;

    public Action(string name, ActionType type=ActionType.Basic)
    {
        actionType = type;
        actionName = name;
        statusAffect = new Dictionary<string, double>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setStatusAffect(double health=0, double affection=0, double intelligence=0, double fame=0, double money=0)
    {
        statusAffect.Add("health", health);
        statusAffect.Add("affection", affection);
        statusAffect.Add("intelligence", intelligence);
        statusAffect.Add("fame", fame);
        statusAffect.Add("money", money);
    }

    public Dictionary<string, double> getStatusAffect()
    {
        return statusAffect;
    }

    public bool checkName(string name)
    {
        return (name == actionName);
    }

    public ActionType getActionType()
    {
        return actionType;
    }
}