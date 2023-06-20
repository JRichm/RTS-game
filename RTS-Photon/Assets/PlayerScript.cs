


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    public GameObject selectedEntity;
    private PlayerMovement playerMovement;
    private UIController uiController;
    private PhotonView view;
    private bool isPaused;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        playerMovement = GetComponent<PlayerMovement>();
        uiController = GetComponentInChildren<UIController>();
        uiController.pauseMenu.enabled = false;
        if (view.IsMine)
        {
            Player localPlayer = PhotonNetwork.LocalPlayer;
            localPlayer.TagObject = GetComponent<PlayerScript>();
        }
    }

    private void Update()
    {
        if (view.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseMenu(!isPaused);
            }
        }
    }

    public void PauseMenu(bool isOpen)
    {
        // don't do anything if the game is already paused
        if (isOpen == isPaused) { return; }

        // open pause menu if game is not paused
        if (isOpen && !isPaused)
        {
            uiController.pauseMenu.enabled = true;
            playerMovement.SetFreeze(true);
            isPaused = true;
        }

        // close pause menu if game is paused
        if (!isOpen && isPaused)
        {
            uiController.pauseMenu.enabled = false;
            playerMovement.SetFreeze(false);
            isPaused = false;
        }
    }
}