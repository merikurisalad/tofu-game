using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Status : MonoBehaviour
{
    // all the attributes are >= 0 and <= 100
    public static int health;
    public static int affection;
    public static int intelligence;
    public static int charm;
    public static int reputation;
    public static int day;

    public const int INITIAL_LOWEST = 1;
    public const int INITIAL_HIGHEST = 10;
    public const int INITIAL_MONEY_LOWEST = 10;
    public const int INITIAL_MONEY_HIGHEST = 101;

    int[] ReturnStatus()
    {
        int[] status = new int[] { health, affection, intelligence, charm, reputation};
        return status;
    }

    int[] ReturnStatusLevel() // Return status in level-form
    {
        int HIGHEST_STATUS_VALUE = 100; // Highest value could be changed
        int interval = HIGHEST_STATUS_VALUE / 5; // Divider could be changed if level system is changeed
        int[] statusLevel = new int[5];
        int[] statusArr = ReturnStatus();
        for (int i = 0; i < 5; i++)
        {
            statusLevel[i] = statusArr[i] / interval;
        }

        return statusLevel;
    }

    // Start is called before the first frame update
    void Start()
    {
        System.Random rand = new System.Random();
        health = rand.Next(INITIAL_LOWEST, INITIAL_HIGHEST);
        affection = rand.Next(INITIAL_LOWEST, INITIAL_HIGHEST);
        intelligence = rand.Next(INITIAL_LOWEST, INITIAL_HIGHEST);
        charm = rand.Next(INITIAL_LOWEST, INITIAL_HIGHEST);
        reputation = rand.Next(INITIAL_LOWEST, INITIAL_HIGHEST);
    }

    public void ChangeHealth(int score)
    {
        health += score;
        // moved from Update (instead of checking every frame, check when health changes)
        CheckGameOver();
    }

    public void ChangeAffection(int score)
    {
        affection += score;
    }

    public void ChangeIntelligence(int score)
    {
        intelligence += score;
    }

    public void ChangeCharm(int score)
    {
        charm += score;
    }

    public void ChangeReputation(int score)
    {
        reputation += score;
    }

    private void CheckGameOver()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
