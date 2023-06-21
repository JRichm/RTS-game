using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPunCallbacks
{
    public float moveSpeed = 5f;
    public float zoomSpeed = 5f;
    public float minZoom = 5f;
    public float maxZoom = 20f;


    public Camera playerCam;
    private PhotonView view;
    private bool isFrozen;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        Debug.LogError(PhotonNetwork.LocalPlayer);

        if (view.IsMine && !isFrozen) // Check if it's the local player's object
        {
            // Player movement
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(-verticalMovement, 0f, horizontalMovement);
            movement = Quaternion.Euler(0f, 45f, 0f) * movement;
            movement.Normalize();

            transform.position += movement * moveSpeed * Time.deltaTime;

            // Camera zoom
            float zoomDelta = Input.GetAxis("Mouse ScrollWheel");
            float newZoom = playerCam.orthographicSize - zoomDelta * zoomSpeed;
            playerCam.orthographicSize = Mathf.Clamp(newZoom, minZoom, maxZoom);
        }
    }

    public void SetFreeze(bool setFrozen)
    {
        isFrozen = setFrozen;
    }
}