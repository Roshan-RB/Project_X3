using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(InputData))]
public class StartGame_button : MonoBehaviour
{
    public Gamelogic3 gameLogic; // Reference to the Gamelogic3 script
    public float raycastDistance = 10f; // Max distance for the raycast
    public LayerMask StartGame; // Layer mask for the panel
    public GameObject StartButton;

    private InputData _inputData;
    private bool triggerPressedThisFrame = false;

    private void Start()
    {
        _inputData = GetComponent<InputData>();

    }

    private void Update()
    {
        // Cast a ray from the controller to detect collisions with objects
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, StartGame))
        {
          
            Debug.Log("Ray hit startbutton!");

            // Check if the trigger button is pressed
            bool triggerValue;
            if (_inputData._rightController.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
            {
                if (triggerPressedThisFrame)
                {
                    triggerPressedThisFrame = true;

                    // If the trigger button is pressed, get the name of the selected ball
                    string selected = hit.collider.gameObject.name;
                    Debug.Log(selected);
                }

                // Start the game
                gameLogic.StartGame();
                Debug.Log("Start button clicked, Game started !!");

                StartButton.SetActive(false);
            }
            else
            {
                triggerPressedThisFrame = false;
            }
        

        }
    }
}
