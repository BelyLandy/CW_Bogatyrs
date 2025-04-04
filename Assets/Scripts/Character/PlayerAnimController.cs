using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    private Vector2 movementInput;

    private PlayerInputHandler inputHandler;

    private SpriteRenderer _spriteRenderer;

    private Transform baseAttackChild;
    
    private Transform pickUpChild;
    
    private void Awake()
    {
        inputHandler = GetComponent<PlayerInputHandler>();
        
        _spriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        
        baseAttackChild = transform.Find("BaseAttack");
        
        pickUpChild = transform.Find("PickUpItems");
    }

    private void OnEnable()
    {
        if (inputHandler != null)
        {
            inputHandler.OnInputChanged += UpdateInput;
        }
    }

    private void OnDisable()
    {
        if (inputHandler != null)
        {
            inputHandler.OnInputChanged -= UpdateInput;
        }
    }

    private void UpdateInput(PlayerInputData inputData)
    {
        movementInput = inputData.MovementInput;
        //MirrorCharacter();
    }
    
    // private void MirrorCharacter()
    // {
    //     if (_spriteRenderer != null)
    //     {
    //         if (movementInput.x < 0)
    //         {
    //             _spriteRenderer.flipX = true;
    //         }
    //         else if (movementInput.x > 0)
    //         {
    //             _spriteRenderer.flipX = false;
    //         }
    //     }
    //     
    //     if (baseAttackChild != null)
    //     {
    //         if (movementInput.x < 0)
    //         {
    //             baseAttackChild.localRotation = Quaternion.Euler(0, 180, 0);
    //         }
    //         else if (movementInput.x > 0)
    //         {
    //             baseAttackChild.localRotation = Quaternion.Euler(0, 0, 0);
    //         }
    //     }
    //
    //     if (pickUpChild != null)
    //     {
    //         if (movementInput.x < 0)
    //         {
    //             pickUpChild.localRotation = Quaternion.Euler(0, 180, 0);
    //         }
    //         else if (movementInput.x > 0)
    //         {
    //             pickUpChild.localRotation = Quaternion.Euler(0, 0, 0);
    //         }
    //     }
    //
    // }
}
