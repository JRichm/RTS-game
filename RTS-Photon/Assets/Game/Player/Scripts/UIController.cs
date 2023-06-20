using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public RenderTexture renderTexture;
    public RawImage miniMapImage;
    public Canvas pauseMenu;
    public GameObject mainButtonsParent;
    private Button[] mainButtons;

    private void Start()
    {
        mainButtons = mainButtonsParent.GetComponentsInChildren<Button>();
    }

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

        for (int i = 0; i < mainButtons.Length; i++)
        {
            Debug.Log(mainButtons[i].GetComponentInChildren<Text>().text);

            if (i < buttonData.Count && buttonData[i] != null)
            {
                mainButtons[i].gameObject.SetActive(true);
                // Assuming the button has an Image component
                Image imageComponent = mainButtons[i].GetComponent<Image>();

                if (imageComponent != null)
                {
                    // Assign the Texture2D to the sprite of the Image component
                    imageComponent.sprite = Sprite.Create(buttonData[i].GetComponent<Entity>().entityIcon, new Rect(0, 0, buttonData[i].GetComponent<Entity>().entityIcon.width, buttonData[i].GetComponent<Entity>().entityIcon.height), Vector2.one * 0.5f);
                }
            } else
            {
                mainButtons[i].gameObject.SetActive(false);
            }
        }
        // loop through buttons
            // if there is button data at index
                // update buttons to display name and image

            // if there is no more button data
                // hide extra buttons
    }
}
