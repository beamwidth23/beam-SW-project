using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private MovemenRigidbody2D moveman2D;
    private PlayerRenderer playerRenderer;
    private PlayerBase playerBase;
    private Vector2 moveInput = Vector2.zero;

    private void Awake()
    {
        moveman2D = GetComponent<MovemenRigidbody2D>();
        playerRenderer = GetComponentInChildren<PlayerRenderer>();
        playerBase = GetComponent<PlayerBase>();
    
    }

    private void Update()
    {
        playerBase.IsMoved = moveInput.x != 0 || moveInput.y !=0;
        if ( moveInput.x != 0 ) playerRenderer.SpriteFlipX(moveInput.x);
        playerRenderer.OnMovement(playerBase.IsMoved ? 1 : 0);
        //먼지 효과 재생
        playerRenderer.OnFootStepEffect(playerBase.IsMoved);
        moveman2D.MoveTo(moveInput);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if ( context.performed || context.canceled )
        {
            moveInput = context.ReadValue<Vector2>();
        }
    }
}