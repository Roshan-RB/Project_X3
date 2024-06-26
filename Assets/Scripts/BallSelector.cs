using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(InputData))]
public class BallSelector : MonoBehaviour
{
    private InputData _inputData;
    public AudioClip selectSound;
    private bool triggerPressed = false;

    private void Start()
    {
        _inputData = GetComponent<InputData>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for trigger input and perform selection action
        CheckTriggerInput();
    }

    void CheckTriggerInput()
    {
        // Check if trigger button is pressed on the right controller
        if (_inputData._rightController.isValid)
        {
            float triggerValue;
            if (_inputData._rightController.TryGetFeatureValue(CommonUsages.trigger, out triggerValue))
            {
                // Check if the trigger is pressed (not just released)
                if (triggerValue > 0.5f && !triggerPressed)
                {
                    triggerPressed = true;
                    RaycastHit hit;
                    // Cast a ray from the controller to detect collisions with mangoes layer
                    if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, LayerMask.GetMask("mangoLayer")))
                    {
                        string selectedBallName = hit.collider.gameObject.name;

                        //guessingGame.CheckGuess(selectedBallName); 

                        Debug.Log("Ball selected: " + selectedBallName); // Perform selection action here
                        PlaySelectSound(); // Play select sound
                    }
                }
                // If trigger released, reset triggerPressed flag
                else if (triggerValue <= 0.5f && triggerPressed)
                {
                    triggerPressed = false;
                }
            }
        }
    }

    void PlaySelectSound()
    {
        // Check if a select sound is assigned
        if (selectSound != null)
        {
            // Create an audio source component and play the select sound
            AudioSource.PlayClipAtPoint(selectSound, transform.position);
        }
    }
}
