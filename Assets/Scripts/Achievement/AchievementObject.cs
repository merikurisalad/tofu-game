using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Achievement", menuName = "Achievement")]
public class AchievementObject : ScriptableObject
{
    public string achievementName;
    public string achievementDescription;
    public bool isUnlocked;
    public Sprite icon;


    public void UnlockAchievement()
    {
        isUnlocked = true;
    }
}

