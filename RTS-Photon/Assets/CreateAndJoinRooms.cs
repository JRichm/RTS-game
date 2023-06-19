

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField roomName;
    public string gameSceneName;

    public void CreateRoom()
    {
        if (PhotonNetwork.InLobby && PhotonNetwork.IsConnectedAndReady)
        {

            RoomOptions roomOptions = new RoomOptions();
            PhotonNetwork.CreateRoom(roomName.text, roomOptions);
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


