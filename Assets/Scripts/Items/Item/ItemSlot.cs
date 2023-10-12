using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemSlot
{
    [field: SerializeField] public ItemSO ItemData { get; private set; }
    [field: SerializeField] public int Quantity { get; private set; }
    public ItemSlot()
    {
        ClearSlot();
    }
    public event Action<ItemSlot> OnItemSlotChanged;
    public bool AddItem(ItemSO item)
    {
        if (ItemData == null)
        {
            ItemData = item;
            Quantity = 1;
            CallEventOnItemSlotChanged();
            return true;
        }
        else if (ItemData == item && ItemData.MaxStackAmount > Quantity)
        {
            Quantity ++;
            CallEventOnItemSlotChanged();
            return true;
        }
        return false;
    }
    public bool RemoveItem(ItemSO item)
    {
        if (ItemData == null) { return false; }
        else if (ItemData != item) { return false; }
        else if (Quantity >= 1) 
        {
            Quantity --;
            if (Quantity == 0)
            {
                ItemData = null;
            }
            CallEventOnItemSlotChanged();
            return true;
        }
        return false;
    }
    public void ClearSlot()
    {
        ItemData = null;
        Quantity = 0;
    }
    public void CallEventOnItemSlotChanged()
    {
        OnItemSlotChanged?.Invoke(this);
    }
}
