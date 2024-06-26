using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;

[RequireComponent(typeof(InputData))]
public class rotate : MonoBehaviour
{
    private InputData _inputData;

    public float rotationSpeed = 5f;

    private void Start()
    {
        _inputData = GetComponent<InputData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 rightAxis))
        {
            // Extract the horizontal and vertical values from the 2D axis
            float horizontal = rightAxis.x;
            float vertical = rightAxis.y;

            // Calculate the rotation based on the input
            Vector3 rotation = new Vector3(vertical, 0, -horizontal) * rotationSpeed * Time.deltaTime;

            // Apply the rotation to the object in its local space
            transform.Rotate(rotation, Space.Self);
        }
    }
}