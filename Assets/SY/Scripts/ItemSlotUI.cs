using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public ItemSlotUI(InventoryUI _inventoryUI, ItemSlot _connectedItemSlot)
    {
        inventoryUI = _inventoryUI;
        connectedItemSlot = _connectedItemSlot;
    }
    [Header("Settings")]
    [SerializeField] Sprite iconSprite;
    [SerializeField] private TextMeshProUGUI quantity;
    [Header("Connections")]
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private ItemSlot connectedItemSlot;

    public void OnSlotClicked()
    {
        inventoryUI.selectedItem = connectedItemSlot;
    }

    public void ConnectSlot(ItemSlot slot)
    {
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
        iconSprite = slot.ItemData.Icon;
        quantity.text = slot.Quantity.ToString();
    }
    public void Refresh()
    {
        if(connectedItemSlot != null) Refresh(connectedItemSlot);
    }
}
