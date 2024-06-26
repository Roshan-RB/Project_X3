using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBallHighlighter : MonoBehaviour
{
    public Material highlightedMaterial; // Material for highlighting
    public float raycastDistance = 10f; // Maximum distance for raycasting

    private Renderer lastHitRenderer; // Renderer of the last hit GameObject
    private Material originalMaterial; // Original material of the last hit GameObject

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
