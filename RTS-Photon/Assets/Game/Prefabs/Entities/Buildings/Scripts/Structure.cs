using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    [SerializeField]
    public string structureName;
    public Texture2D structureIcon;
    public int startingHealth;
    public int purchasePrice;
    public List<GameObject> structureEntities;

    public virtual void OnClick()
    {
        // default handling 
        // add common behavior or leave empty
    }
}





