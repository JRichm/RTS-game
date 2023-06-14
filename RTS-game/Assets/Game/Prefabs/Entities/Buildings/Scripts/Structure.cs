using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    public string structureName;
    public int startingHealth;
    public List<GameObject> structureEntities;

    private int owner;
    private int structureHealth;

    [SerializeField]
    public virtual void OnClick()
    {
        // default handling 
        // add common behavior or leave empty
    }
}





