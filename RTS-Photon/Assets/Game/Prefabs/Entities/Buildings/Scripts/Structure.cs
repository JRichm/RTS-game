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

    private UIController uiController;

    public virtual void OnClick()
    {
        
    }
}