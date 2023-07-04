using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotationController : MonoBehaviour
{
    public float rotationSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        // Get the user input for arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the rotation amount based on input and speed
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // Create a rotation vector
        Vector3 rotationVector = new Vector3(-verticalInput, horizontalInput, 0f) * rotationAmount;

        // Apply rotation to the light
        transform.Rotate(rotationVector);
    }
}
