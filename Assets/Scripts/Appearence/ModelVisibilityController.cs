using UnityEngine;
using UnityEngine.UI;

public class ModelVisibilityController : MonoBehaviour
{
    public GameObject modelObject; // Reference to the GameObject representing the 3D model
    public Toggle toggleButton; // Reference to the Toggle UI element

    // Start is called before the first frame update
    void Start()
    {
        // Add listener to the Toggle's value changed event
        toggleButton.onValueChanged.AddListener(OnToggleValueChanged);
    }

    // Method to handle Toggle value change
    void OnToggleValueChanged(bool isOn)
    {
        // Set the visibility of the modelObject based on the Toggle state
        modelObject.SetActive(isOn);
    }
}
