using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class InventoryUI : MonoBehaviour
{
    [Header("Inspect CurrentState")]
    [SerializeField] public ItemSlot selectedItem;
   
    [Header("Panel Settings")]
    public ItemSlotUI[] items_UI;
    [Header("Selected Item Info")]
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescription;
    public TextMeshProUGUI selectedItemStatNames;
    public TextMeshProUGUI selectedItemStatValues;
    [Header("Buttons")]
    public GameObject useButton;
    public GameObject equipButton;
    public GameObject unequipButton;
    public GameObject placeButton;
    public GameObject dropButton;
    [Header("Connections")]
    public Inventory connectedInventory;

    [Header("Events")]
    public UnityEvent onOpenInventory;
    public UnityEvent onCloseInventory;

    public void Toggle()
    {
        if (gameObject.activeInHierarchy)
        {

            gameObject.SetActive(false);
            onCloseInventory?.Invoke();
        }
        else
        {
            gameObject.SetActive(true);
            onOpenInventory?.Invoke();
        }
    }
    public void ConnectInventory(Inventory inventory)
    {
        ItemSlot[] items = inventory.Items;
        for (int i = 0; i < inventory.Items.Length; i++)
        {
            items_UI[i].ConnectSlot(items[i]);
            items_UI[i].Refresh(items[i]);
        }
    }
    public void SelectItem(ItemSlot item)
    {
        if (item.ItemData == null)
        {
            Clear_SelectedItemInfo();
            return;
        }
        else
        {
            selectedItem = item;
        }
        Refresh_SelectedItemInfo();
        SetButtons_SelectedItemInfo();
    }
    public void Clear_SelectedItemInfo()
    {
        selectedItem = null;

        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;
        selectedItemStatNames.text = string.Empty;
        selectedItemStatValues.text = string.Empty;
    }
    public void Refresh_SelectedItemInfo()
    {
        selectedItemName.text = selectedItem.ItemData.DisplayName;
        selectedItemDescription.text = selectedItem.ItemData.Description;

        selectedItemStatNames.text = string.Empty;
        selectedItemStatValues.text = string.Empty;

        if (selectedItem.ItemData.Consumables != null)
        {
            for (int i = 0; i < selectedItem.ItemData.Consumables.Length; i++)
            {
                selectedItemStatNames.text += selectedItem.ItemData.Consumables[i].Type.ToString() + "\n";
                selectedItemStatValues.text += selectedItem.ItemData.Consumables[i].Value.ToString() + "\n";
            }
        }
    }
    public void SetButtons_SelectedItemInfo()
    {
        if (selectedItem == null)
        {
            useButton.SetActive(false);
            equipButton.SetActive(false);
            unequipButton.SetActive(false);
            dropButton.SetActive(false);
            placeButton.SetActive(false);
        }
        else
        {
            useButton.SetActive(selectedItem.ItemData.Type == ItemType.Item);
            //equipButton.SetActive(selectedItem.ItemData.Type == ItemType.Item && !slots[index].isEquipped);
            //unequipButton.SetActive(selectedItem.item.Type == ItemType.Equipable && slots[index].isEquipped);
            //placeButton.SetActive(selectedItem.item.Type == ItemType.Installable);
            dropButton.SetActive(true);
        }
    }
    public void OnUseButton()
    {
        //        //if (selectedItem.item.Type == ItemType.Consumable)
        //        //{
        //        //    for (int i = 0; i < selectedItem.item.Consumables.Length; i++)
        //        //    {
        //        //        switch (selectedItem.item.Consumables[i].Type)
        //        //        {
        //        //            case ConsumableType.Hunger:
        //        //                player.AddHunger((float)selectedItem.item.Consumables[i].Value,false);
        //        //                break;

        //        //            case ConsumableType.Thirst:
        //        //                player.AddThirst((float)selectedItem.item.Consumables[i].Value,false);
        //        //                break;
        //        //            case ConsumableType.Health:
        //        //                player.AddHp((float)selectedItem.item.Consumables[i].Value, false);
        //        //                break;
        //        //            case ConsumableType.Stamina:
        //        //                player.AddStamina((float)selectedItem.item.Consumables[i].Value, false);
        //        //                break;
        //        //        }
        //        //    }
        //        //}
        selectedItem.RemoveItem(selectedItem.ItemData);
    }
    //    public void OnEquipButton()
    //    {
    //        if (!isExistEquipInventory)
    //        {
    //            EquipHere();
    //        }
    //    }
    //    public void OnUnequipButton()
    //    {
    //        if (!isExistEquipInventory)
    //        {
    //            UnequipHere();
    //        }
    //    }

    //    public void OnPlaceButton()
    //    {
    //        //GameObject prefab = selectedItem.item.InstallablePrefab;

    //        //bool isSuccess = installer.InstallObject(prefab);
    //        //if (isSuccess) RemoveSelectedItem();
    //    }
    public void OnDropButton()
    {
        selectedItem.RemoveItem(selectedItem.ItemData);
        connectedInventory.ThrowItem(selectedItem.ItemData,1);
    }
}
