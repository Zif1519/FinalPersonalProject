using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InventoryUI : MonoBehaviour
{
    [Header("Panel Settings")]
    public ItemSlotUI[] uiSlots;
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
    

    //    [Header("Selected Item")]
    //    [SerializeField] private ItemSlot selectedItem;
    //    private int selectedItemIndex;



    [SerializeField] public Inventory ConnectedInventory { get; private set; }

    //    [Header("Events")]
    //    public UnityEvent onOpenInventory;
    //    public UnityEvent onCloseInventory;

    //    private void Start()
    //    {
    //        inventoryPanel.SetActive(false);
    //        slots = new ItemSlot[uiSlots.Length];

    //        for(int i= 0; i <slots.Length ; i++)
    //        {
    //            slots[i] = new ItemSlot();
    //            uiSlots[i].myindex = i;
    //            uiSlots[i].Clear();
    //        }
    //        for( int i= 0; i < startItems.Length ; i++)
    //        {
    //            AddItem(startItems[i]);
    //        }

    //        ClearSelectedItemWindow();

    //public void Toggle()
    //    {
    //        if (inventoryPanel.activeInHierarchy)
    //        {
    //            inventoryPanel.SetActive(false);
    //            onCloseInventory?.Invoke();
    //            UpdateUI();

    //        }
    //        else
    //        {
    //            inventoryPanel.SetActive(true);
    //            onOpenInventory?.Invoke();
    //            UpdateUI();
    //        }
    //    }



    //    public bool IsOpen()
    //    {
    //        return inventoryPanel.activeInHierarchy;
    //    }



    //    public void SelectItem(int index)
    //    {
    //        if (slots[index].item == null) return;

    //        selectedItem = slots[index];
    //        selectedItemIndex = index;

    //        selectedItemName.text = selectedItem.item.DisplayName;
    //        selectedItemDescription.text = selectedItem.item.Description;

    //        selectedItemStatNames.text = string.Empty;
    //        selectedItemStatValues.text = string.Empty;

    //        if(selectedItem.item.Consumables != null) 
    //        {
    //            for (int i = 0; i < selectedItem.item.Consumables.Length; i++)
    //            {
    //                selectedItemStatNames.text += selectedItem.item.Consumables[i].Type.ToString() + "\n";
    //                selectedItemStatValues.text += selectedItem.item.Consumables[i].Value.ToString() + "\n";
    //            }
    //        }


    //        //useButton.SetActive(selectedItem.item.Type == ItemType.Consumable);
    //        //equipButton.SetActive(selectedItem.item.Type == ItemType.Equipable && !slots[index].isEquipped);
    //        //unequipButton.SetActive(selectedItem.item.Type == ItemType.Equipable && slots[index].isEquipped);
    //        //placeButton.SetActive(selectedItem.item.Type == ItemType.Installable);
    //        //dropButton.SetActive(true);
    //    }
    //    public void ClearSelectedItemWindow()
    //    {
    //        selectedItem = null;
    //        selectedItemName.text = string.Empty;
    //        selectedItemDescription.text = string.Empty;

    //        selectedItemStatNames.text = string.Empty;
    //        selectedItemStatValues.text = string.Empty;

    //        useButton.SetActive(false);
    //        equipButton.SetActive(false);
    //        unequipButton.SetActive(false);
    //        dropButton.SetActive(false);
    //        placeButton.SetActive(false);
    //    }

    //    public void OnUseButton()
    //    {
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
    //        RemoveSelectedItem();
    //    }


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

    //    public void OnDropButton()
    //    {
    //        //ThrowItem(selectedItem.item);
    //        //RemoveSelectedItem();
    //    }
    public void Toggle()
    {

    }

    public void Refresh()
    {

    }
    public void Connect(Inventory inventory)
    {
        ConnectedInventory = inventory;
        Refresh();
    }
}
