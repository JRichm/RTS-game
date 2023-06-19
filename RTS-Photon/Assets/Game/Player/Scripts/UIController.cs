using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public RenderTexture renderTexture;
    public RawImage miniMapImage;

    private void Update()
    {
        if (miniMapImage != null && renderTexture != null)
        {
            miniMapImage.texture = renderTexture;
        }
    }
}
