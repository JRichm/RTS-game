using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{    
    public class ButtonData
    {
        public string buttonString;
        public Image buttonImage;
        public GameObject buttonEntity;
    }

    [SerializeField]
    public List<ButtonData> buttonDataList = new List<ButtonData>();
    public int farts;

    public void Start()
    {
        
    }
}
