


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    private int currentPlayerIndex = 0;

    private Vector3[] spawnPositions = new Vector3[]
    {
        new Vector3(-50f, 0f, -50f),
        new Vector3(50f, 0f, -50f),
        new Vector3(-50f, 0f, 50f),
        new Vector3(50f, 0f, 50f)
    };

    private void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            StartCoroutine(SpawnPlayersWithDelay());
        }
    }

    private IEnumerator SpawnPlayersWithDelay()
    {
        yield return new WaitForSeconds(currentPlayerIndex  * 1f); // Adjust the delay as needed

        SpawnPlayer();

        yield return new WaitForSeconds(currentPlayerIndex * 1f); // Adjust the delay as needed

        if (currentPlayerIndex < PhotonNetwork.PlayerList.Length)
        {
            StartCoroutine(SpawnPlayersWithDelay());
        }
    }

    private void SpawnPlayer()
    {
        if (currentPlayerIndex < PhotonNetwork.PlayerList.Length)
        {
            Vector3 spawnPosition = spawnPositions[currentPlayerIndex];
            GameObject newPlayer = PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, Quaternion.identity);
            currentPlayerIndex++;
        }
    }

    public override void OnJoinedRoom()
    {
        currentPlayerIndex = PhotonNetwork.PlayerList.Length - 1;
        SpawnPlayer();
    }
}


