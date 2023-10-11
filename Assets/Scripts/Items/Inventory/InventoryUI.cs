using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryUI : MonoBehaviour
{
    public ItemSlotUI[] uiSlots;
    [SerializeField] public Inventory ConnectedInventory {  get; private set; }
    //    [Header("Selected Item")]
    //    [SerializeField] private ItemSlot selectedItem;
    //    private int selectedItemIndex;
    //    public TextMeshProUGUI selectedItemName;
    //    public TextMeshProUGUI selectedItemDescription;
    //    public TextMeshProUGUI selectedItemStatNames;
    //    public TextMeshProUGUI selectedItemStatValues;
    //    public GameObject useButton;
    //    public GameObject equipButton;
    //    public GameObject unequipButton;
    //    public GameObject dropButton;
    //    public GameObject placeButton;



    //    [Header("Events")]
    //    public UnityEvent onOpenInventory;
    //    public UnityEvent onCloseInventory;

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
