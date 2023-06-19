


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviour
{
    [SerializeField]
    public GameObject selectedEntity;
    public delegate void OnClickCallback();
    public static event OnClickCallback OnClickEvent;

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

    public void UpdateUI(GameObject clickObj)
    {
        // update the ui based on the selected object
        // add your ui update logic here
    }

    public void PauseMenu(bool isOpen)
    {
        Debug.Log(uiController);
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