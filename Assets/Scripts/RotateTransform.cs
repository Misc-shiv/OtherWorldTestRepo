using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTransform : MonoBehaviour
{

    // Adds Translate Function [SerializeField] private float moveSpeed = 10f
    [SerializeField] private float turnSpeed = 50f;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);

        //if (Input.GetKey(KeyCode.UpArrow))
            //transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);

        //if (Input.GetKey(KeyCode.DownArrow))
            //transform.Rotate(-Vector3.up, turnSpeed * Time.deltaTime);

    }
}
