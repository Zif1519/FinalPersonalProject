using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemSlot
{
    [field: SerializeField] public ItemData ItemData { get; private set; }
    [field: SerializeField] public int Quantity { get; private set; }
    [field: SerializeField] public ItemSlotUI ConnectedSlotUI { get; private set; }
    [field: SerializeField] public bool IsCleared { get; private set; }

    public ItemSlot()
    {
        ClearSlot();
    }
    public bool AddItem(ItemData item, int amount)
    {
        if (IsCleared)
        {
            ItemData = item;
            Quantity = amount;
            IsCleared = false;
            return true;
        }
        else if (ItemData == item && ItemData.MaxStackAmount >= amount + Quantity)
        {
            Quantity += amount;
            return true;
        }
        return false;
    }
    public bool AddItem(ItemData item)
    {
        return AddItem(item, 1);
    }
    public void ClearSlot()
    {
        ItemData = null;
        ConnectedSlotUI = null;
        IsCleared = true;
        Quantity = 0;
    }
}
