using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData")]
public class ItemData : ScriptableObject
{
    // index must match the cell index in the gameplay UI 
    [SerializeField] private int _itemIdex;
    [SerializeField] private Sprite _icon;

    public int ItemIndex => _itemIdex;
    public Sprite Icon => _icon; 
}
