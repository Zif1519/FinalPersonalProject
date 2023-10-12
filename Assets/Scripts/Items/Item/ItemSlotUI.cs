using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Image icon;
    [SerializeField] private TextMeshProUGUI quantity;
    [Header("Connections")]
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private ItemSlot connectedItemSlot;

    public void OnSlotClicked()
    {
        inventoryUI.SelectItem(connectedItemSlot);
    }

    public void ConnectSlot(ItemSlot slot, InventoryUI inventory)
    {
        inventoryUI = inventory;
        connectedItemSlot = slot;
        slot.OnItemSlotChanged += Refresh;
    }
    public void DisconnectSlot()
    {
        connectedItemSlot.OnItemSlotChanged -= Refresh;
        connectedItemSlot = null;
    }
    public void Refresh(ItemSlot slot)
    {
        if (slot.ItemData == null)
        {
            icon.sprite = null;
            quantity.text = "";
            return;
        }
        icon.sprite = slot.ItemData.Icon;
        quantity.text = slot.Quantity.ToString();
    }
    public void Refresh()
    {
        if(connectedItemSlot != null) Refresh(connectedItemSlot);
    }
}
