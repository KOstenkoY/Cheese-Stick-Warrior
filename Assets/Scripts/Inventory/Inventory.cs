using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<InventoryItem> _inventoryItemsList = new List<InventoryItem>();
    private Dictionary<ItemData, InventoryItem> _itemDictionary = new Dictionary<ItemData, InventoryItem>();

    public void Add(ItemData itemData)
    {
        if(_itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(itemData);
            _inventoryItemsList.Add(newItem);
            _itemDictionary.Add(itemData, newItem);
        }
    }

    public void Remove(ItemData itemData)
    {
        if (_itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.RemoveFromStack();

            if (item.StackSize == 0)
            {
                _inventoryItemsList.Remove(item);
                _itemDictionary.Remove(itemData);
            }
        }
    }
}
