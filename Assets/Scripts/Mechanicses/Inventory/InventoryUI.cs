using System;
using System.Collections;
using System.Collections.Generic;
using AbstractClasses;
using GameUI;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private InventoryCells[] _cells;
    
    [SerializeField]private GameObject _cellPrefab;
    [SerializeField] private GameObject _inventoryPanel;
    
    private void Start()
    {
        Inventory inventory = FindObjectOfType<Inventory>();
        
        _cells = new InventoryCells[inventory.GetSize()];
        for (int i = 0; i < inventory.GetSize(); i++)
        {
            _cells[i] = Instantiate(_cellPrefab, Vector3.zero, Quaternion.identity, _inventoryPanel.transform).
                GetComponent<InventoryCells>();
            
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
           SetInventoryVisible(!_inventoryPanel.activeSelf);
        }
    }

    public void SetInventoryVisible(bool visible)
    {
        _inventoryPanel.SetActive(visible);
    }
    
    private InventoryCells GetNextEmptyCell()
    {
        foreach (InventoryCells cell in _cells)
        {
            if (cell.IsEmpty)
            {
                return cell;
            }
        }

        return null;
    }

    public void UpdateCells(InventoriableItem[] items)
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            if (items[i] != null)
            {
                _cells[i].SetNewIcon(items[i].Icon);
            }
            else
            {
                break;
            }
        }
    }
}
