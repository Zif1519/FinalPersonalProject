using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using static UnityEditor.Progress;

[Serializable]
public class Inventory : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] public InventorySO inventorySO;
    [SerializeField] public ItemSlot[] Items => inventorySO.Items;

    [Header("Start Items")]
    [SerializeField] private InventorySO startItem;

    [Header("Connections")]
    [SerializeField] public InventoryUI connected_UI;

    private Player player;

    //  나중에 장착창에 옮기자
    //    private int curEquipIndex;
    //    private bool isExistEquipInventory;
    //    private EquipInventory equipInventory;
    //        if(TryGetComponent(out EquipInventory equipInventory))
    //        {
    //            isExistEquipInventory = true;
    //        }
    //        else
    //        {
    //            equips = new ItemSlot[3];
    //            for (int i = 0; i < equips.Length; i++)
    //            {
    //                equips[i] = new ItemSlot();
    //            }
    //        }
    //    }
    //    public void UnequipHere()
    //    {

    //        //selectedItem.isEquipped = false;
    //        //if (equips[0] == selectedItem)
    //        //{
    //        //    //player.UnEquipWeapon(equips[0].item.WeaponPrefab);
    //        //    equips[0] = null;
    //        //}


    //        //UpdateUI();
    //        //SelectItem(selectedItemIndex);
    //    }

    //    public void EquipHere()
    //    {
    //        //selectedItem.isEquipped = true;
    //        //if (equips[0] != null) equips[0].isEquipped = false;
    //        //equips[0] = selectedItem;

    //        ////player.EquipWeapon(selectedItem.item.WeaponPrefab);

    //        //UpdateUI();
    //        //SelectItem(selectedItemIndex);
    //    }

    private void Awake()
    {
        player = GetComponent<Player>();
    }
    private void Start()
    {
        player.Input.PlayerActions.Inventory.started += ToggleUI;
        connected_UI.ConnectInventory(this);
        InputStartItems(startItem);
    }
    private void OnDestroy()
    {
        player.Input.PlayerActions.Inventory.started -= ToggleUI;
    }
    private void InputStartItems(InventorySO startItemSO)
    {
        if (startItemSO == null) return;
        ItemSlot[] items = startItemSO.Items;
        for (int i=0; i <items.Length ; i++)
        {
            AddItem(items[i].ItemData, items[i].Quantity);
        }
    }
    private void ToggleUI(InputAction.CallbackContext context)
    {
        connected_UI.Toggle();
    }
    public void AddItem(ItemData item, int amount)
    {
        if (item == null) return;
        int remains = amount;
        ItemSlot slot;
        while (remains > 0)
        {
            slot = GetStackableSlot(item);
            if (slot != null) 
            { 
                slot.AddItem(item);
                remains--;
                continue;
            }
            else
            {
                slot = GetEmptySlot();
                if (slot != null)
                {
                    slot.AddItem(item);
                    remains--;
                    continue;
                }
                break;
            }
        }
        ThrowItem(item, remains);
    }
    public void RemoveItem(ItemData item, int amount)
    {
        if (item == null) return;
        int remains = amount;
        ItemSlot slot;
        while (remains > 0)
        {
            slot = GetItemSlot(item);
            if ( slot != null)
            {
                slot.RemoveItem(item);
                remains--;
                continue;
            }
            break;
        }
    }
    public void ThrowItem(ItemData item, int amount) 
    {
        if (item == null) return;
        Debug.Log(item.DisplayName + " 아이템을 " + amount.ToString() + " 개 버렸다.");
    }
    public int CheckCountAddable(ItemData item)
    {
        if (item == null) return 0;
        int count = 0;
        for ( int i = 0; i < Items.Length; i++ )
        {
            if (Items[i].ItemData == null)
            {
                count += item.MaxStackAmount;
            }
            else if (Items[i].ItemData == item)
            {
                count += item.MaxStackAmount - Items[i].Quantity;
            }
        }
        return count;
    }
    public int CheckCountItem(ItemData item)
    {
        if (item == null) return 0;
        int count = 0;
        for( int i = 0;i < Items.Length;i++ )
        {
            if (Items[i].ItemData == item)
            {
                count += Items[i].Quantity;
            }
        }
        return count;
    }
    public ItemSlot GetItemSlot(ItemData item)
    {
        if (item == null) return null;
        for (int i=0; i <Items.Length; i++)
        {
            if (Items[i].ItemData == item) return Items[i];
        }
        return null;
    }
    public ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i].ItemData == null) return Items[i];
        }
        return null;
    }
    public ItemSlot GetStackableSlot(ItemData item)
    {
        if (item == null) return null;
        for (int i=0; i < Items.Length; ++i)
        {
            if (Items[i].ItemData == item && item.MaxStackAmount > Items[i].Quantity) return Items[i];
        }
        return null;
    }
}
