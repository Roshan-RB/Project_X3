using UnityEngine;

public class round_manager : MonoBehaviour
{
    public int totalRounds = 5;
    private int currentRound = 1;

    public void StartGame()
    {
        StartRound();
    }

    private void StartRound()
    {
        // Show UI elements for the current round
        Debug.Log("Starting Round " + currentRound);
        // Enable interaction with the balls
        // Implement ball selection logic here
    }

    public void EndRound()
    {
        // Disable interaction with the balls
        Debug.Log("Round " + currentRound + " completed.");
        currentRound++;
        if (currentRound <= totalRounds)
        {
            StartRound();
        }
        else
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        // Show game over screen or return to main menu
        Debug.Log("Game Over");
    }
}
