using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    private void OnMouseDown()
    {
        Structure structure = GetComponent<Structure>();

        if (structure != null) structure.OnClick();
    }
}
