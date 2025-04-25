using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCells : MonoBehaviour
{
    public Sprite ItemIcon { get; private set; }
    public bool IsEmpty { get; private set; } = true;


    public void SetNewIcon(Sprite newIcon)
    {
        ItemIcon = newIcon;
        GetComponent<Image>().sprite = ItemIcon;
    }
    
    
}
