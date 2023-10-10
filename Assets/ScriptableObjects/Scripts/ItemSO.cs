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
    public string DisplayName;
    public string Description;
    public ItemType Type;
    public Sprite Icon;
    public GameObject DropPrefab;
    public GameObject WeaponPrefab;
    public GameObject InstallablePrefab;
    public GameObject SummonPrefab;

    [Header("Stacking")]
    public bool IsStackable;
    public int MaxStackAmount;

    [Header("Consumable")]
    public ItemDataConsumable[] Consumables;
}
