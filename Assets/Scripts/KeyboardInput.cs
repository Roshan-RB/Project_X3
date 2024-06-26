using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public Gamelogic3 gameLogic; // Reference to the Gamelogic3 script

    private void Update()
    {
        // Check if the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Call the StartGame method on the Gamelogic3 script
            gameLogic.StartGame();
        }
    }
}
