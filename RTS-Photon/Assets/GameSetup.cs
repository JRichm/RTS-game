using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class GameSetup : MonoBehaviour
{
    public TMP_Text lobbyCode;
    public Button playButton;
    public float delayBeforeLoad = 2f;

    private PhotonView photonView;


    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();

        if (PhotonNetwork.InRoom)
        {
            lobbyCode.text = PhotonNetwork.CurrentRoom.Name;
        }
        else
        {
            lobbyCode.text = "ERROR";
        }

        if (!PhotonNetwork.IsMasterClient)
        {
            playButton.gameObject.SetActive(false);
        } else
        {
            playButton.onClick.AddListener(LoadGameScene);
        }
    }

    public void LoadGameScene()
    {
        StartCoroutine(LoadGameSceneWithDelay());
    }

    private IEnumerator LoadGameSceneWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoad);

        if (PhotonNetwork.IsMasterClient)
        {
            // inform other players to load the scene
            photonView.RPC("LoadGameSceneRPC", RpcTarget.All);
        }
    }

    [PunRPC]
    private void LoadGameSceneRPC()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
