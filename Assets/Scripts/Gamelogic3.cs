using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(InputData))]
public class Gamelogic3 : MonoBehaviour
{
    public GameObject level1;
    public GameObject level2;

    public Material highlightedMaterial; // Material for highlighting
    public float raycastDistance = 10f; // Maximum distance raycasting
    public AudioClip goodAudioClip; // Audio clip for correct selections
    public AudioClip badAudioClip; // Audio clip for incorrect selections
    public Text correctText; // Text to display correct score
    public Text incorrectText; // Text to display incorrect score
    public Text RoundNumberText;
    public List<string> correctOptionsPerRound = new List<string> { "C_ball1", "C_ball2", "C_ball3", "C_ball4", "C_ball5" }; // List of correct options for round
    public AudioClip gameMusicClip; // Audio clip for game music
    
    public GameObject StartButton;
    public GameObject endGameButton; // Reference to the UI button for ending the game
    public GameObject restartGameButton; // Reference to the UI button for restarting the game
    public GameObject next_level_button;
    public float delayBeforeButtons = 2f; // Delay before showing end game and restart game buttons

    public List<RenderTexture> roundRenderTextures = new List<RenderTexture>(); // List of render textures for each round
    public RawImage roundRenderTextureImage; // UI Image element to display the render texture



    private InputData _inputData;
    private Renderer lastHitRenderer; // Renderer of the last hit GameObject
    private Material originalMaterial; // Original material of the last hit GameObject
    private AudioSource audioSource; // AudioSource component to play the audio

    private int currentRound = 0; // Start from 0 to align with list indices
    private int correctScore = 0;
    private int incorrectScore = 0;

    // Flag to track whether the trigger was pressed in the current frame
    private bool triggerPressedThisFrame = false;

    private bool gameStarted = false; // Flag to track whether the game has started

    private XRInteractorLineVisual lineVisual; // Declare the variable

    //StartToggle start;

    private void Start()
    {
        // initialize gameboject1 and gameobject2
        level1.SetActive(true);
        level2.SetActive(false);

        _inputData = GetComponent<InputData>();
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to the same GameObject

        lineVisual = GetComponent<XRInteractorLineVisual>();

        if (lineVisual == null)
        {
            Debug.LogError("XRInteractorLineVisual component not found!");
            return;
        }

        // Disable end game and restart game buttons initially
        endGameButton.SetActive(false);
        restartGameButton.SetActive(false);
        next_level_button.SetActive(false);

    }

    public void StartGame()
    {
        if (!gameStarted)
        { 
        gameStarted = true;
        
        // Assign game music clip to the AudioSource component
        if (audioSource != null &&  gameMusicClip != null && !audioSource.isPlaying)
        {
            audioSource.clip = gameMusicClip;
            audioSource.Play();
        }

        if (StartButton != null)
        {
            StartButton.SetActive(false);
        }

        // Reset scores and other necessary variables
        correctScore = 0;
        incorrectScore = 0;
        currentRound = 0;

        // Update the text elements to display initial scores
        UpdateScoreText();

        // Print "Game Started" to debug
        Debug.Log("Game Started");

        // Start the first round
        StartRound();
        }
    }

    private void StartRound()
    {
        currentRound++;
        if (currentRound <= correctOptionsPerRound.Count)
        {
            // Update UI to indicate the current round
            Debug.Log("Round "+currentRound+" Started!");
            UpdateRoundText();

            // Display the corresponding render texture for the current round
            if (roundRenderTextures.Count >= currentRound)
            {
                roundRenderTextureImage.texture = roundRenderTextures[currentRound - 1];
            }
            else
            {
                Debug.LogWarning("Render texture for round " + currentRound + " not found.");
            }

            // Other setup tasks for the round
            AssignCorrectOption();
        }
        
        else
        {
            EndGame();
        }

        if (currentRound > 5)
        {
            next_level_button.SetActive(true);
            restartGameButton.SetActive(true);
            endGameButton.SetActive(false);  
        }
    }

    private void AssignCorrectOption()
    {
        // Get the correct option for the current round from the list
        string correctOption = correctOptionsPerRound[currentRound - 1];
        Debug.Log("Correct option for Round " + currentRound + ": " + correctOption);
    }

    private void Update()
    {
        RaycastHit hit;

        Color defaultRayColor = Color.red; // Your current red color
        Color highlightRayColor = Color.green; // Highlight color when pointing at an object

        
        int layerMask = LayerMask.GetMask("StartGame","EndGame","RestartGame","BallLayer", "NextLevel");
        


        // Cast a ray from the controller to detect collisions with objects
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance,layerMask))
        {
            
            // Check if the hit object belongs to the "StartGame" layer
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("StartGame"))
            {
                HandleButtonPress(hit, highlightRayColor, () => StartGame());
                return; // Exit the Update method to prevent further processing
            }

            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("NextLevel"))
            {
                HandleButtonPress(hit, highlightRayColor, () => OnNextLevelButtonPressed());
            }

            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("RestartGame"))
            {
                HandleButtonPress(hit, highlightRayColor, () => RestartGame());
            }
            else
            {
                ResetRayColor(defaultRayColor);
            }

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

                        // Compare the selected ball name with the correct option for the current round
                        if (selectedBallName == correctOptionsPerRound[currentRound - 1])
                        {
                            // If the selected ball is correct, play the good audio clip
                            if (goodAudioClip != null && audioSource != null)
                            {
                                audioSource.PlayOneShot(goodAudioClip);
                            }
                            Debug.Log("Correct option selected: " + hit.collider.gameObject.name);
                            correctScore++;
                        }
                        else
                        {
                            // If the selected ball is incorrect, play the bad audio clip
                            if (badAudioClip != null && audioSource != null)
                            {
                                audioSource.PlayOneShot(badAudioClip);
                            }
                            Debug.Log("Incorrect option selected: " + hit.collider.gameObject.name + "| Correct option is: " + correctOptionsPerRound[currentRound - 1]);
                            incorrectScore++;
                        }
                        // Update score text elements
                        UpdateScoreText();
                        StartRound();
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
            // Default ray color when not hitting anything
            ResetRayColor(defaultRayColor);
            // If the ray doesn't hit anything, reset the material of the last hit GameObject
            if (lastHitRenderer != null)
            {
                lastHitRenderer.material = originalMaterial;
                lastHitRenderer = null;
            }
        }
    }

    private void ResetRayColor(Color defaultRayColor)
    {
        lineVisual.validColorGradient = new Gradient() { colorKeys = new GradientColorKey[] { new(defaultRayColor, 0f) } };
    }

    private void HandleButtonPress(RaycastHit hit, Color highlightRayColor, Action buttonAction)
    {
        lineVisual.validColorGradient = new Gradient() { colorKeys = new GradientColorKey[] { new(highlightRayColor, 0f) } };
        bool triggerValue;
        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            // If the trigger button is pressed and it wasn't pressed in the previous frame
            if (!triggerPressedThisFrame)
            {
                // Set the flag to indicate that the trigger was pressed in this frame
                triggerPressedThisFrame = true;

                // Call the button action
                buttonAction.Invoke();
                //Debug.Log(debugMessage);
            }
        }
        else
        {
            // Reset the flag if the trigger button is not pressed in this frame
            triggerPressedThisFrame = false;
        }
    }

    private void UpdateRoundText()
    {
        StartCoroutine(DelayBeforeButtons());
        RoundNumberText.text = "Round: " + currentRound;
        
    }

    // Update the text elements to display the current scores
    private void UpdateScoreText()
    {
        correctText.text = "Correct: " + correctScore;
        incorrectText.text = "Incorrect: " + incorrectScore;
    }

    private void EndGame()
    {

        // Stop the music
        audioSource.Stop();


        // Display game over screen or return to main menu
        Debug.Log("Game Over");

        
        StartCoroutine(DelayBeforeButtons());

        // Enable end game and restart game buttons
        endGameButton.SetActive(true);
        restartGameButton.SetActive(true);
    }

    private void OnNextLevelButtonPressed()
    {

        StartCoroutine(DelayBeforeButtons());

        // Reset scores and other necessary variables
        correctScore = 0;
        incorrectScore = 0;
        currentRound = 0;

        // Update the text elements to display initial scores
        UpdateScoreText();

        // Set the initial state of game objects for the next level
        if (level1 != null) level1.SetActive(false);
        if (level2 != null) level2.SetActive(true);

        Debug.Log("Next level Button Pressed: Level1 deactivated, Level2 activated");
        
        // Start the next level
        StartRound();
    }

    private void RestartGame()
    {
        StartCoroutine(DelayBeforeButtons());

        // Reset the flag for game started
        gameStarted = false;

        Debug.Log("Game Restarted!");

        // Reset scores and other necessary variables
        correctScore = 0;
        incorrectScore = 0;
        currentRound = 0;

        // Update the text elements to display initial scores
        UpdateScoreText();

        // Set the initial state of game objects
        if (level1 != null && level1.activeSelf)
        {
            level1.SetActive(true);
            level2.SetActive(false);
            Debug.Log("Restarting level 1");
        }
        else if (level2 != null && level2.activeSelf)
        {
            level1.SetActive(false);
            level2.SetActive(true);
            Debug.Log("Restarting level 2");
        }

        // Disable end game and restart game buttons again
        if (endGameButton != null)
        {
            endGameButton.SetActive(false);
            Debug.Log("End game button deactivated");
        }
        if (restartGameButton != null)
        {
            restartGameButton.SetActive(false);
            Debug.Log("Restart game button deactivated");
        }

        // Start the game
        StartGame();
    }


    private IEnumerator DelayBeforeButtons()
    {
        yield return new WaitForSeconds(delayBeforeButtons);

        // Enable end game and restart game buttons
        //endGameButton.SetActive(true);
        //restartGameButton.SetActive(true);
    }
}
