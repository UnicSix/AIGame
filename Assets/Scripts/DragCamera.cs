using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag: MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 15.0f;
    [SerializeField] private float movementSpeed = 80.0f;
    [SerializeField] private float zoomSpeed = 50.0f;
    [SerializeField] private float minZoom = 15.0f;
    [SerializeField] private float maxZoom = 150.0f;

    private Vector3 lastMousePosition;

    void Update()
    {
        ZoomCamera(Input.GetAxis("Mouse ScrollWheel"));
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            // Record the current mouse position when either mouse button is pressed
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(1)) // Right mouse button
        {
            // Calculate the difference in mouse position
            Vector3 delta = Input.mousePosition - lastMousePosition;
            lastMousePosition = Input.mousePosition;

            // Apply rotation
            float angleX = delta.y * rotationSpeed * Time.deltaTime;
            float angleY = -delta.x * rotationSpeed * Time.deltaTime;

            transform.eulerAngles += new Vector3(angleX, angleY, 0);
        }

        if (Input.GetMouseButton(0)) // Left mouse button
        {
            // Calculate the difference in mouse position
            Vector3 delta = Input.mousePosition - lastMousePosition;
            lastMousePosition = Input.mousePosition;

            // Apply movement
            Vector3 movement = new Vector3(-delta.x, -delta.y, 0) * movementSpeed * Time.deltaTime;
            transform.Translate(movement, Space.World);
        }
    }

    void ZoomCamera(float increment)
    {
        if (Camera.main.orthographic)
        {
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize-increment*zoomSpeed, minZoom, maxZoom);
        }
        else
        {
            // For perspective camera
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - increment * zoomSpeed, minZoom, maxZoom);
        }
    }
}