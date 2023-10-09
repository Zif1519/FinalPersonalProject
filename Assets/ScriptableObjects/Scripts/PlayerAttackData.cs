using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AttackInfoData
{
    [field: SerializeField] public string AttackName { get; private set; }
    [field: SerializeField] public int ComboStateIndex { get; private set; }
    [field: SerializeField, Range(0f, 1f)] public float ComboTransitionTime { get; private set; }
    [field: SerializeField, Range(0f, 3f)] public float ForceTransitionTime { get; private set; }
    [field: SerializeField, Range(-10f, 10f)] public float Force { get; private set; }

    [field: SerializeField] public int Damage { get; private set; }
}

[Serializable]
public class PlayerAttackData
{
    [field: SerializeField] public List<AttackInfoData> attackInfoDatas { get; private set; }
    public int GetAttackInfoCount() 
    {  
        return attackInfoDatas.Count; 
    }
    public AttackInfoData GetAttackInfo(int index) 
    { 
        return attackInfoDatas[index]; 
    }
}
