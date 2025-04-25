using System.Collections;
using System.Collections.Generic;
using GameUI;
using UnityEngine;
using UnityEngine.UI;

namespace AbstractClasses
{
    public abstract class InventoriableItem : UsableObject
    {
        public Sprite Icon;

        public override void Use()
        {
            FindObjectOfType<Inventory>().PutItemInInventory(gameObject.GetComponent<InventoriableItem>());
            Hint.SetHintVisible(false);
        }
    }
}
