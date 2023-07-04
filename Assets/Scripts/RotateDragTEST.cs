using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDragTEST : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    bool dragging = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnMouseDrag()
    {
        dragging = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            dragging = false;
        }
    }

    void FixedUpdate()
    {
        if (dragging)
        {
            float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;
            float Y = Input.GetAxis("Mouse Y") * rotationSpeed * Time.fixedDeltaTime;

        }
    }
}
