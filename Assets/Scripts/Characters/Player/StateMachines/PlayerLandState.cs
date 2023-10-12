using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerAirState
{
    public PlayerLandState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.LandParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.LandParameterHash);
    }

    public override void Update()
    {
        base.Update();
        if (stateMachine.Player.Controller.isGrounded)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
            return;
        }
    }
}
