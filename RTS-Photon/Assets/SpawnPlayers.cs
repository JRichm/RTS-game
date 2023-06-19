

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject startStructurePrefab;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void Start()
    {
        // Generate random position within the specified range
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector2 randomPosition = new Vector3(randomX, 0, randomY);

        // Instantiate the player at the random position
        GameObject instantiatedPlayer = PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);

        // Instantiate the building at the same position as the player
        GameObject instantiatedBuilding = PhotonNetwork.Instantiate(startStructurePrefab.name, instantiatedPlayer.transform.position, Quaternion.Euler(90f, 90f, 0f));

        // Assign ownership of the building to the player
        PhotonView photonView = instantiatedBuilding.GetComponent<PhotonView>();
        if (photonView != null)
        {
            photonView.TransferOwnership(instantiatedPlayer.GetComponent<PhotonView>().Owner);
        }
    }
}



