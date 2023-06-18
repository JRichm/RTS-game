using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera playerCam;

    public float moveSpeed = 20f;  // Speed of the player movement
    public float zoomSpeed = 20f;  // Speed of camera zoom
    public float minZoomFOV = 20f;  // Minimum field of view for zoom
    public float maxZoomFOV = 60f;  // Maximum field of view for zoom
    public float scrollBoundary = 15f; // Distance from screen edge to trigger scrolling

    private Vector3 moveDirection;  // Direction of the player movement

    private float screenWidth;
    private float screenHeight;

    private void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    void Update()
    {
        // Read input for horizontal movement
        float horizontalInput = 0f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            horizontalInput = -1f;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            horizontalInput = 1f;

        // Read input for vertical movement
        float verticalInput = 0f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            verticalInput = 1f;
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            verticalInput = -1f;

        // Calculate movement direction relative to the camera
        Vector3 cameraForward = playerCam.transform.forward;
        cameraForward.y = 0; // Ignore vertical component for movement
        cameraForward.Normalize();
        Vector3 cameraRight = playerCam.transform.right;
        cameraRight.y = 0; // Ignore vertical component for movement
        cameraRight.Normalize();

        moveDirection = (cameraForward * verticalInput + cameraRight * horizontalInput).normalized;

        // Move the player
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Handle camera zoom
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0f)
        {
            float zoomAmount = scrollInput * zoomSpeed;
            float newFOV = playerCam.fieldOfView - zoomAmount;
            newFOV = Mathf.Clamp(newFOV, minZoomFOV, maxZoomFOV);
            playerCam.fieldOfView = newFOV;
        }

        // Handle camera movement with mouse edge scrolling
        Vector3 mousePosition = Input.mousePosition;

        if (mousePosition.x < scrollBoundary)
        {
            transform.Translate(cameraRight * -moveSpeed * Time.deltaTime);
        }
        else if (mousePosition.x > screenWidth - scrollBoundary)
        {
            transform.Translate(cameraRight * moveSpeed * Time.deltaTime);
        }

        if (mousePosition.y < scrollBoundary)
        {
            transform.Translate(cameraForward * -moveSpeed * Time.deltaTime);
        }
        else if (mousePosition.y > screenHeight - scrollBoundary)
        {
            transform.Translate(cameraForward * moveSpeed * Time.deltaTime);
        }
    }
}
