using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    private void OnMouseDown()
    {
        Structure structure = GetComponent<Structure>();
        Entity entity = GetComponent<Entity>();

        if (structure != null) structure.OnClick();
        if (entity != null) entity.OnClick();
    }
}
