using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : Structure
{
    public UIController uiController;


    private void Start()
    {
    }

    public override void OnClick()
    {
        //base.OnClick();
        Debug.Log("I am a " + this.structureName);

        if (uiController != null)
        {
            Debug.Log("update UI");
        }
    }
}
