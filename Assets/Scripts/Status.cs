using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Status : MonoBehaviour
{
    // all the attributes are >= 0 and <= 100
    public static double health;
    public static double affection;
    public static double intelligence;
    public static double fame;

    public const double INITIAL_LOWEST = 1.0;
    public const double INITIAL_HIGHEST = 5.0;
    public const double INITIAL_MONEY_LOWEST = 10.0;
    public const double INITIAL_MONEY_HIGHEST = 101.0;
    public const double HIGHEST_STATUS_VALUE = 100.0;
    public const double LOWEST_STATUS_VALUE = 0.0;
    public const int NUM_STAGE = 3;

    public DateTime startDate;
    public int inGameDaysPlayed;

    public double[] ReturnStatus()
    {
        double[] status = new double[] { health, affection, intelligence, fame};
        return status;
    }

    public int[] ReturnStatusLevel() // Return status in level-form
    {
        int interval = (int) HIGHEST_STATUS_VALUE / NUM_STAGE;
        int[] statusLevel = new int[4];
        double[] statusArr = ReturnStatus();
        for (int i = 0; i < 4; i++)
        {
            statusLevel[i] = (int) statusArr[i] / interval;
        }

        return statusLevel;
    }

    // Start is called before the first frame update
    void Start()
    {
        System.Random rand = new System.Random();
        double randomDouble = rand.NextDouble();
        health = (INITIAL_HIGHEST - INITIAL_LOWEST) * randomDouble + INITIAL_LOWEST;
        randomDouble = rand.NextDouble();
        affection = (INITIAL_HIGHEST - INITIAL_LOWEST) * randomDouble + INITIAL_LOWEST;
        randomDouble = rand.NextDouble();
        intelligence = (INITIAL_HIGHEST - INITIAL_LOWEST) * randomDouble + INITIAL_LOWEST;
        randomDouble = rand.NextDouble();
        fame = (INITIAL_HIGHEST - INITIAL_LOWEST) * randomDouble + INITIAL_LOWEST;
    }

    public void ChangeHealth(double score)
    {
        health += score;
        // moved from Update (instead of checking every frame, check when health changes)
        CheckGameOver();
    }

    public void ChangeAffection(double score)
    {
        affection += score;
    }

    public void ChangeIntelligence(double score)
    {
        intelligence += score;
    }

    public void ChangeFame(double score)
    {
        fame += score;
    }

    private void CheckGameOver()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
