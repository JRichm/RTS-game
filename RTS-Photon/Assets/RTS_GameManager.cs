using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RTS_GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    public List<Structure> playerStructures;

    private void Start()
    {
        if (PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue("sceneName", out object sceneNameObj))
        {
            string sceneName = (string)sceneNameObj;
            PhotonNetwork.LoadLevel(sceneName);
        }
    }
}
