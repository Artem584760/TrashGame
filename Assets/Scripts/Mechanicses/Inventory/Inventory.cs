using System;
using System.Collections.Generic;
using System.Linq;
using AbstractClasses;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameUI
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private InventoriableItem[] _itemsInInventory;

        [SerializeField] private Transform handPointTransform;

        private InventoryUI _inventoryUI;

       [SerializeField] private int _size;
       
       public int GetSize() => _size;

        private void Start()
        {
            _inventoryUI = FindObjectOfType<InventoryUI>();
            _itemsInInventory = new InventoriableItem[_size];
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                GetItemInHand(_itemsInInventory[0]);
            }
        }

        public void PutItemInInventory(InventoriableItem item)
        {
            _itemsInInventory[GetNextEmptyIndex()] = item;
            _inventoryUI.UpdateCells(_itemsInInventory);
            item.gameObject.SetActive(false);
        }

        public void GetItemInHand(InventoriableItem item)
        {
            if (!_itemsInInventory.Any(n => n == item))
                return;

            item.gameObject.transform.position = handPointTransform.position + new Vector3(1, 0, 2);
            item.gameObject.SetActive(true);
        }

        private int GetNextEmptyIndex()
        {
            foreach (var item in _itemsInInventory)
            {
                if (item == null)
                {
                    return Array.IndexOf(_itemsInInventory,item);
                }
            }

            return -1;
        }
    }
}
