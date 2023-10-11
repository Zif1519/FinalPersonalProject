using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InventoryType { Character, Shop, CraftingBox, Chest}

[CreateAssetMenu(fileName = "Inventory", menuName = "Items/Inventory")]
[Serializable]
public class InventorySO : ScriptableObject
{
    [field: SerializeField] public int SlotCount {  get; private set; }
    [field: SerializeField] public ItemSlot[] Items {  get; private set; }
    [field: SerializeField] public InventoryType Type { get; private set; }

}
