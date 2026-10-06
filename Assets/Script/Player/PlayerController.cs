using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private MovemenRigidbody2D moveman2D;
    private PlayerRenderer playerRenderer;
<<<<<<< HEAD
    private PlayerBase playerBase;
=======
>>>>>>> 9a96f984d014df9fb86685c45e00ebf704c98260
    private Vector2 moveInput = Vector2.zero;

    private void Awake()
    {
        moveman2D = GetComponent<MovemenRigidbody2D>();
        playerRenderer = GetComponentInChildren<PlayerRenderer>();
<<<<<<< HEAD
        playerBase = GetComponent<PlayerBase>();
=======
>>>>>>> 9a96f984d014df9fb86685c45e00ebf704c98260
    
    }

    private void Update()
    {
<<<<<<< HEAD
        playerBase.IsMoved = moveInput.x != 0 || moveInput.y !=0;
        if ( moveInput.x != 0 ) playerRenderer.SpriteFlipX(moveInput.x);
        playerRenderer.OnMovement(playerBase.IsMoved ? 1 : 0);
        //먼지 효과 재생
        playerRenderer.OnFootStepEffect(playerBase.IsMoved);
=======
        bool isMoved = moveInput.x != 0 || moveInput.y !=0;
        if ( moveInput.x != 0 ) playerRenderer.SpriteFlipX(moveInput.x);
        playerRenderer.OnMovement(isMoved ? 1 : 0);
        //먼지 효과 재생
        playerRenderer.OnFootStepEffect(isMoved);
>>>>>>> 9a96f984d014df9fb86685c45e00ebf704c98260
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