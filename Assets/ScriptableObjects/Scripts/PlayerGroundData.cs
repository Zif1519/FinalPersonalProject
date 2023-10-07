using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerGroundData
{
    [field: SerializeField, Range(0f, 25f)] public float BaseSpeed { get; private set; } = 5f;
    [field: SerializeField, Range(0f, 25f)] public float BaseRotationDamping { get; private set; } = 1f;
    [field: Header("IdleData")]
    [field: Header("WalkData")]
    [field: SerializeField, Range(0f, 2f)] public float WalkSpeedModifier { get; private set; } = 0.25f;
    [field: Header("RunData")]
    [field: SerializeField, Range(0f, 2f)] public float RunSpeedModifier { get; private set; } = 1f;
}
