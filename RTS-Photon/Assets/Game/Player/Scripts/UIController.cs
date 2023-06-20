using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public RenderTexture renderTexture;
    public RawImage miniMapImage;
    public Canvas pauseMenu;

    private void Update()
    {
        if (miniMapImage != null && renderTexture != null)
        {
            miniMapImage.texture = renderTexture;
        }
    }

    public void UpdateMainButtons(List<GameObject> buttonData)
    {
        Debug.Log(buttonData);
        // loop through buttons
            // if there is button data at index
                // update buttons to display name and image

            // if there is no more button data
                // hide extra buttons
    }
}
