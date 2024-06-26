using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    // Lists of good and bad ball names
    public List<string> goodBallNames = new List<string> { "C_ball1", "C_ball2", "C_ball3", "C_ball4", "C_ball5" };
    public List<string> badBallNames = new List<string> { "ball1", "ball2", "ball3", "ball4", "ball5", "ball6", "ball7", "ball8" };

    // Current round number
    private int currentRound = 0;

    // Manually assign the correct ball for each round
    public List<string> correctBalls = new List<string>();

    // Start the next round
    public void StartNextRound()
    {
        currentRound++;
        if (currentRound > correctBalls.Count)
        {
            Debug.Log("All rounds completed!");
            return;
        }

        string correctBallName = correctBalls[currentRound - 1];
        List<string> roundBallNames = new List<string> { correctBallName };

        // Randomly select and add incorrect ball names from the bad ball names list
        while (roundBallNames.Count < 13) // Add 12 incorrect options (total 13 balls including the correct one)
        {
            string randomBall = badBallNames[Random.Range(0, badBallNames.Count)]; // Select a random ball
            if (!roundBallNames.Contains(randomBall)) // Make sure it's not already in the list
            {
                roundBallNames.Add(randomBall); // Add it to the list
            }
        }

        // Now you have a list of 13 ball names for this round, including the correct one
        // You can use this list to set up the round in your game
        Debug.Log("Round " + currentRound + " started. Correct ball: " + correctBallName);
    }
}
