using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public ItemSlotUI(InventoryUI inventoryUI, ItemSlot connectedItemSlot, int slotIndex)
    {
        InventoryUI = inventoryUI;
        ConnectedItemSlot = connectedItemSlot;
        SlotIndex = slotIndex;
    }

    [SerializeField] public InventoryUI InventoryUI { get; private set; }
    [SerializeField] public ItemSlot ConnectedItemSlot { get; private set; }
    [SerializeField] public int SlotIndex { get; private set; }





}
