


using Photon.Pun;
using System.Collections;
using UnityEngine;

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
        if (PhotonNetwork.IsConnectedAndReady && PhotonNetwork.IsMasterClient)
        {
            //StartCoroutine(SpawnPlayersWithDelay());
            StartCoroutine(SpawnPlayersRoutine());
        }
    }

    private IEnumerator SpawnPlayersRoutine()
    {
        Debug.LogError("spawning playaer " + currentPlayerIndex);
        if (currentPlayerIndex < PhotonNetwork.PlayerList.Length)
        {
            Vector3 spawnPosition = spawnPositions[currentPlayerIndex];
            GameObject spawnedPlayer = PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, Quaternion.identity);

            // Get the PhotonView component of the spawned player object
            PhotonView photonView = spawnedPlayer.GetComponent<PhotonView>();

            // Set the ownership of the PhotonView to the current player
            photonView.TransferOwnership(PhotonNetwork.PlayerList[currentPlayerIndex]);

            // Attach the input script to the player object
            //spawnedPlayer.AddComponent<PlayerMovement>();

            currentPlayerIndex++;
        }

        yield return new WaitForSeconds(1f);
        StartCoroutine(SpawnPlayersRoutine());
    }

    private IEnumerator SpawnPlayersWithDelay()
    {
        // wait for one second
        yield return new WaitForSeconds(currentPlayerIndex  * 1f);

        // spawn player
        SpawnPlayer();

        // wait for another second
        yield return new WaitForSeconds(currentPlayerIndex * 1f);

        // start loop if there are more players to spawn
        if (currentPlayerIndex < PhotonNetwork.PlayerList.Length)
        {
            // start coroutine
            StartCoroutine(SpawnPlayersWithDelay());
        }
    }

    // spawn player function
    private void SpawnPlayer()
    {
        // check amount of players against playerlist again
        if (currentPlayerIndex < PhotonNetwork.PlayerList.Length)
        {
            // get spawn position based on player number
            Vector3 spawnPosition = spawnPositions[currentPlayerIndex];

            // instantiate playerobject on photon network
            GameObject newPlayer = PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, Quaternion.identity);

            // increase player number/index
            currentPlayerIndex++;
        }
    }

    // spawn player if joining after game started
    public override void OnJoinedRoom()
    {

        // get player index from playerlist length
        currentPlayerIndex = PhotonNetwork.PlayerList.Length - 1;

        // spawn player
        SpawnPlayer();
    }
}


