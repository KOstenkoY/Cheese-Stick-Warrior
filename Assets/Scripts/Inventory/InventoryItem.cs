using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItem 
{
    private ItemData _itemData;
    private int _stackSize;

    public int StackSize => _stackSize;

    public InventoryItem(ItemData itemData)
    {
        _itemData = itemData;
        AddToStack();
    }

    public void AddToStack()
    {
        _stackSize++;
    }

    public void RemoveFromStack()
    {
        _stackSize--;
    }
}
