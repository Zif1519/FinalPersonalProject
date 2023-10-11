using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Map,
    Tool,
    Item,
    Character
}

public enum ConsumableType
{
    Hunger,
    Thirst,
    Health,
    Stamina
}

[Serializable]
public class ItemDataConsumable
{
    public ConsumableType Type;
    public int Value;
}

[CreateAssetMenu(fileName = "Item", menuName = "Items/Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    [field: SerializeField] private string displayName;
    public string DisplayName => displayName;
    public string Description { get; private set; }
    public ItemType Type { get; private set; }
    public Sprite Icon { get; private set; }
    public GameObject DropPrefab {  get; private set; }
    public GameObject WeaponPrefab {  get; private set; }
    public GameObject InstallablePrefab { get; private set; }
    public GameObject SummonPrefab { get; private set; }

    [Header("Stacking")]
    [field: SerializeField] private bool isStackable;
    public bool IsStackable => isStackable;
    public int MaxStackAmount { get; private set; }

    [Header("Consumable")]
    [field: SerializeField] private ItemDataConsumable[] consumables;
    public ItemDataConsumable[] Consumables => consumables;
}
