

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
            System.Random random = new System.Random();

            int randomNum = random.Next(16777216);
            string roomHexCode = randomNum.ToString("X6");

            RoomOptions roomOptions = new RoomOptions();
            PhotonNetwork.CreateRoom(roomHexCode, roomOptions);
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
        PhotonNetwork.LoadLevel("GameSetup");
    }
}


