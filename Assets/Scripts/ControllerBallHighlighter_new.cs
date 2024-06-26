using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(InputData))]
public class ControllerBallHighlighter_new : MonoBehaviour
{
    public Material highlightedMaterial; // Material for highlighting
    public float raycastDistance = 10f; // Maximum distance for raycasting
    public AudioClip triggerSound; // Sound to play when the trigger is presses

    private InputData _inputData;
    private Renderer lastHitRenderer; // Renderer of the last hit GameObject
    private Material originalMaterial; // Original material of the last hit GameObject
    private AudioSource audioSource;
    private void Start()
    {
        _inputData = GetComponent<InputData>();
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to the gameobject
    }

    // Remove one of the Update methods
    private void Update()
    {
        RaycastHit hit;
        // Cast a ray from the controller to detect collisions with the "Spheres" layer
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
                    // If the trigger button is pressed, debug log a message
                    Debug.Log("Trigger button is pressed on " + hit.collider.gameObject.name);

                    // Play the trigger sound
                    if(triggerSound != null && audioSource!= null)
                    {
                        Debug.Log("Playing trigger sound");
                        audioSource.PlayOneShot(triggerSound);
                    }
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
}
