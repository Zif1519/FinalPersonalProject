using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }

    // States
    public PlayerIdleState IdleState { get; }
    public PlayerWalkState WalkState { get; }
    public PlayerRunState RunState { get; }

    public PlayerJumpState JumpState { get; }
    public PlayerLandState LandState { get; }

    public PlayerComboAttackState ComboAttackState { get; }
    


    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1.0f;

    public float JumpForce { get; set; }

    public bool IsAttacking { get; set; }
    public int ComboIndex {  get; set; }
    public Transform MainCameraTransform { get; set; }

    public PlayerStateMachine(Player player)
    {
        Player = player;

        IdleState = new PlayerIdleState(this);
        RunState = new PlayerRunState(this);
        WalkState = new PlayerWalkState(this);

        JumpState = new PlayerJumpState(this);
        LandState = new PlayerLandState(this);

        ComboAttackState = new PlayerComboAttackState(this);

        MainCameraTransform = Camera.main.transform;
        MovementSpeed = player.PlayerData.GroundData.BaseSpeed;
        RotationDamping = player.PlayerData.GroundData.BaseRotationDamping;
    }
}
