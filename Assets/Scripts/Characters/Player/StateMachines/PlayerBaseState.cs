using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBaseState : IState
{
    protected PlayerStateMachine stateMachine;
    protected readonly PlayerSO playerData;
    protected CinemachinePOV virtualCameraPOV;

    public PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        stateMachine = playerStateMachine;
        playerData = stateMachine.Player.PlayerData;
        virtualCameraPOV = playerStateMachine.Player.VirtualCamera.GetCinemachineComponent<CinemachinePOV>();
    }
    public virtual void Enter()
    {
        AddInputActionsCallbacks();
    }

    public virtual void Exit()
    {
        RemoveInputActionsCallbacks();
    }

    public virtual void HandleInput()
    {
        ReadMovementInput();
        ReadCursorLockInput();
    }

    public virtual void PhysicsUpdate()
    {
        
    }

    public virtual void Update()
    {
        Move();
    }


    protected virtual void AddInputActionsCallbacks()
    {
        PlayerInput input = stateMachine.Player.Input;
        input.PlayerActions.Movement.canceled += OnMovementCanceled;
        input.PlayerActions.Run.started += OnRunStarted;
        input.PlayerActions.Jump.started += OnJumpStarted;
    }

    protected virtual void RemoveInputActionsCallbacks()
    {
        PlayerInput input = stateMachine.Player.Input;
        input.PlayerActions.Movement.canceled -= OnMovementCanceled;
        input.PlayerActions.Run.started -= OnRunStarted;
        input.PlayerActions.Jump.started -= OnJumpStarted;
    }

    protected virtual void OnRunStarted(InputAction.CallbackContext context)
    {

    }
    protected virtual void OnMovementCanceled(InputAction.CallbackContext context)
    {

    }
    protected virtual void OnJumpStarted(InputAction.CallbackContext context)
    {

    }

    private void ReadMovementInput()
    {
        PlayerInput input = stateMachine.Player.Input;
        stateMachine.MovementInput = input.PlayerActions.Movement.ReadValue<Vector2>();
    }
    private void ReadCursorLockInput()
    {
        if (Cursor.lockState != CursorLockMode.Locked && stateMachine.Player.Input.PlayerActions.CursorLock.IsPressed())
        { 
            Cursor.lockState = CursorLockMode.Locked;
            virtualCameraPOV.m_VerticalAxis.m_MaxSpeed = 5f;
            virtualCameraPOV.m_HorizontalAxis.m_MaxSpeed = 5f;
        }
        if (Cursor.lockState == CursorLockMode.Locked && !stateMachine.Player.Input.PlayerActions.CursorLock.IsPressed())
        {
            Cursor.lockState = CursorLockMode.None;
            virtualCameraPOV.m_VerticalAxis.m_MaxSpeed = 0f;
            virtualCameraPOV.m_HorizontalAxis.m_MaxSpeed = 0f;
        }
    }
    private void Move()
    {
        Vector3 movementDirection = GetMovementDirection();
        Rotate(movementDirection);
        Move(movementDirection);
    }

    private Vector3 GetMovementDirection()
    {
        Vector3 forward = stateMachine.MainCameraTransform.forward;
        Vector3 right = stateMachine.MainCameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        return forward* stateMachine.MovementInput.y + right* stateMachine.MovementInput.x;
    }

    private void Move(Vector3 direction)
    {
        float movementSpeed = GetMovementSpeed();
        stateMachine.Player.Controller.Move(
            ((direction * movementSpeed )
            + stateMachine.Player.ForceReceiver.Movement)* Time.deltaTime
            );
    }
    private void Rotate(Vector3 direction)
    {
        if( direction != Vector3.zero )
        {
            Transform playerTransform = stateMachine.Player.transform;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, stateMachine.RotationDamping * Time.deltaTime);
        }
    }
    
    private float GetMovementSpeed()
    {
        float speed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;
        return speed;
    }

    protected void StartAnimation(int animationHash)
    {
        stateMachine.Player.Animator.SetBool(animationHash, true);
    }
    protected void StopAnimation(int animationHash)
    {
        stateMachine.Player.Animator.SetBool(animationHash, false);
    }
    
}
