using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : PlayerStructure
{
    public override void OnClick()
    {
        //base.OnClick();
        Debug.Log("I am a " + this.structureName);
    }
}
