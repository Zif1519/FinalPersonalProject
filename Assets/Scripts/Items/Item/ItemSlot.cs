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
    public bool AddItem(ItemData item)
    {
        if (IsCleared)
        {
            ItemData = item;
            Quantity ++;
            IsCleared = false;
            return true;
        }
        else if (ItemData == item && ItemData.MaxStackAmount > Quantity)
        {
            Quantity ++;
            return true;
        }
        return false;
    }
    public bool RemoveItem(ItemData item)
    {
        if (IsCleared || ItemData == null) { return false; }
        if (ItemData != item) { return false; }
        else if (Quantity >= 1) 
        {
            Quantity --;
            if (Quantity == 0)
            {
                ClearSlot();
            }
            return true;
        }
        return false;
    }
    public void ClearSlot()
    {
        ItemData = null;
        ConnectedSlotUI = null;
        IsCleared = true;
        Quantity = 0;
    }
}
