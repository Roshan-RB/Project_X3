using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

[RequireComponent(typeof(InputData))]
public class Gamelogic2 : MonoBehaviour
{
    public Material highlightedMaterial; // Material for highlighting
    public float raycastDistance = 10f; // Maximum distance for raycasting
    public AudioClip goodAudioClip; // Audio clip for good balls
    public AudioClip badAudioClip; // Audio clip for bad balls
    public Text correctText; //Text to display correct score
    public Text incorrectText;//Text to display incorrect score

    private InputData _inputData;
    private Renderer lastHitRenderer; // Renderer of the last hit GameObject
    private Material originalMaterial; // Original material of the last hit GameObject
    private AudioSource audioSource; // AudioSource component to play the audio

    //Score for correct and incorrect options
    private int correctScore = 0;
    private int incorrectScore = 0;

    // Lists of good and bad ball names
    private List<string> goodBallNames = new List<string> { "C_ball1", "C_ball2", "C_ball3", "C_ball4", "C_ball5" };
    private List<string> badBallNames = new List<string> { "ball1", "ball2", "ball3", "ball4", "ball5", "ball6", "ball7", "ball8" };

    // Flag to track whether the trigger was pressed in the current frame
    private bool triggerPressedThisFrame = false;

    private void Start()
    {
        _inputData = GetComponent<InputData>();
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to the same GameObject

        //Update the text elements to display initial scores
        UpdateScoreText();

    }

    private void Update()
    {
        RaycastHit hit;
        // Cast a ray from the controller to detect collisions with the "mangoLayer" layer
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, LayerMask.GetMask("mangoLayer")))
        {
            Renderer renderer = hit.collider.GetComponent<Renderer>();
            if (renderer != null)
            {
                // If the ray hits a GameObject with a Renderer component
                if (lastHitRenderer != renderer)
                {
                    // If this is a new GameObject, reset the material of the previous one
                    if (lastHitRenderer != null)
                    {
                        lastHitRenderer.material = originalMaterial;
                    }
                    // Update the lastHitRenderer and originalMaterial
                    lastHitRenderer = renderer;
                    originalMaterial = renderer.material;
                }
                // Change the material of the hit GameObject
                renderer.material = highlightedMaterial;

                // Check if the trigger button is pressed
                bool triggerValue;
                if (_inputData._rightController.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
                {
                    // If the trigger button is pressed and it wasn't pressed in the previous frame
                    if (!triggerPressedThisFrame)
                    {
                        // Set the flag to indicate that the trigger was pressed in this frame
                        triggerPressedThisFrame = true;

                        // If the trigger button is pressed, get the name of the selected ball
                        string selectedBallName = hit.collider.gameObject.name;

                        // Check if the selected ball is good or bad
                        if (goodBallNames.Contains(selectedBallName))
                        {
                            // If the selected ball is good, play the good audio clip
                            if (goodAudioClip != null && audioSource != null)
                            {
                                audioSource.PlayOneShot(goodAudioClip);
                            }
                            Debug.Log("Correct option selected: " + hit.collider.gameObject.name);
                            correctScore++;
                        }

                        else if (badBallNames.Contains(selectedBallName))
                        {
                            // If the selected ball is bad, play the bad audio clip
                            if (badAudioClip != null && audioSource != null)
                            {
                                audioSource.PlayOneShot(badAudioClip);
                            }
                            Debug.Log("Incorrect option selected: " + hit.collider.gameObject.name);
                            incorrectScore++;
                        }
                        UpdateScoreText();
                    }
                }
                else
                {
                    // Reset the flag if the trigger button is not pressed in this frame
                    triggerPressedThisFrame = false;
                }
            }
        }
        else
        {
            // If the ray doesn't hit anything, reset the material of the last hit GameObject
            if (lastHitRenderer != null)
            {
                lastHitRenderer.material = originalMaterial;
                lastHitRenderer = null;
            }
        }
    }

    // Update the text elements to display the current scores
    private void UpdateScoreText()
    {
        correctText.text = "Correct: " + correctScore;
        incorrectText.text = "Incorrect: " + incorrectScore;
    }
}
