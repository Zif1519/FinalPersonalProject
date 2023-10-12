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
public class ItemSO : ScriptableObject
{
    [Header("Info")]
    [field: SerializeField] private string displayName;
    public string DisplayName => displayName;
    [field: SerializeField] string description;
    public string Description => description;
    [field: SerializeField] private ItemType type;
    public ItemType Type => type;
    [field: SerializeField] private Sprite icon;
    public Sprite Icon => icon;
    [field: SerializeField] private GameObject dropPrefab;
    public GameObject DropPrefab => dropPrefab;
    [field: SerializeField] private GameObject weaponPrefab;
    public GameObject WeaponPrefab => weaponPrefab;
    [field: SerializeField] private GameObject installPrefab;
    public GameObject InstallablePrefab => installPrefab;
    [field: SerializeField] private GameObject summonPrefab;
    public GameObject SummonPrefab=> summonPrefab;

    [Header("Stacking")]
    [field: SerializeField] private bool isStackable;
    public bool IsStackable => isStackable;
    [field: SerializeField] private int maxStackAmount;
    public int MaxStackAmount => maxStackAmount;
    [Header("Consumable")]
    [field: SerializeField] private ItemDataConsumable[] consumables;
    public ItemDataConsumable[] Consumables => consumables;
}
