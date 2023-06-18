

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
        if (PhotonNetwork.InLobby && PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.CreateRoom(roomName.text);
        } else
        {
            Debug.LogError("In Lobby: " + PhotonNetwork.InLobby + "\nConnected and Ready: " + PhotonNetwork.IsConnectedAndReady);
        }
    }

    public void JoinRoom()
    {
        if (PhotonNetwork.InLobby && PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.JoinRoom(roomName.text);
        } else
        {
            Debug.LogError("In Lobby: " + PhotonNetwork.InLobby + "\nConnected and Ready: " + PhotonNetwork.IsConnectedAndReady);
        }

    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}