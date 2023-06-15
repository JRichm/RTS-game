using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField roomName;

    public void CreateRoom()
    {
        if (PhotonNetwork.InLobby)
        {
            PhotonNetwork.CreateRoom(roomName.text);
        }
        else
        {
            Debug.LogError("Not in lobby. Wait for OnJoinedLobby callback.");
        }
    }

    public void JoinRoom()
    {
        if (PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinRoom(roomName.text);
        }
        else
        {
            Debug.LogError("Not in lobby. Wait for OnJoinedLobby callback.");
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined lobby.");
        // Now that we are in the lobby, you can enable the UI for creating/joining rooms if needed
    }
}