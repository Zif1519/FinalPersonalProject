using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerBaseState
{
    public PlayerGroundState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.GroundParameterHash);
    }
    public override void Exit() 
    { 
        base.Exit();
        StartAnimation(stateMachine.Player.AnimationData.GroundParameterHash);
    }
    public override void HandleInput()
    {
        base.HandleInput();
    }
    public override void Update()
    {
        base.Update();
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
