

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ClickHandler : MonoBehaviour
{
    private void OnMouseDown()
    {
        Structure structure = GetComponent<Structure>();
        Entity entity = GetComponent<Entity>();

        if (structure != null && IsOwnedByPlayer())
        {
            structure.OnClick();
            CallPlayerUpdateUI(structure.structureEntities);
        }
        else if (entity != null && IsOwnedByPlayer())
        {
            entity.OnClick();
        }
    }

    private bool IsOwnedByPlayer()
    {
        
        // Check if object has PhotonView and if it has any owner at all
        PhotonView photonView = GetComponent<PhotonView>();

        if (photonView != null && photonView.Owner != null)
        {
            // Compare the owner's PhotonPlayer ID with the local player's PhotonPlayer ID
            return photonView.Owner.ActorNumber == PhotonNetwork.LocalPlayer.ActorNumber;
        }

        // Default to false if ownership cannot be determined
        return false;
    }

    private void CallPlayerUpdateUI(List<GameObject> buttonData)
    {
        Photon.Realtime.Player localPhotonPlayer = PhotonNetwork.LocalPlayer;
        PlayerScript localPlayer = localPhotonPlayer.TagObject as PlayerScript;

        if (localPlayer != null)
        {
            localPlayer.GetComponentInChildren<UIController>().UpdateMainButtons(buttonData);
        }
    }
}


