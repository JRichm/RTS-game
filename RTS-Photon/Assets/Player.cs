


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviour
{
    [SerializeField]
    public GameObject selectedEntity;
    public delegate void OnClickCallback();
    public static event OnClickCallback OnClickEvent;


    private bool paused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.LogError(paused);
        }
    }

    public void UpdateUI(GameObject clickObj)
    {
        // update the ui based on the selected object
        // add your ui update logic here
    }
}