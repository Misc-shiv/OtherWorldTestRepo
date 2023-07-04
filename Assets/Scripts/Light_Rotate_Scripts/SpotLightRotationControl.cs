using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightRotationControl : MonoBehaviour
{
    public Transform spotlightHolder;
    public float rotationSpeed = 100f;

    private void Update()
    {
        // Get input from arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the rotation amount based on input and speed
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // Rotate the spotlight holder object
        spotlightHolder.Rotate(Vector3.up, horizontalInput * rotationAmount);
        spotlightHolder.Rotate(Vector3.right, verticalInput * rotationAmount);
    }
}





