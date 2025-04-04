using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 
/// </summary>
public class PlayerInputHandler : MonoBehaviour
{
    //private GameInput input;

    private Vector2 movementInput;
    private bool isAttacking;
    private bool isScrollingLeft;
    private bool isScrollingRight;
    private bool isPaused;
    
    private ColliderAttack _attack;

    public event Action<PlayerInputData> OnInputChanged;

    private void Awake()
    {
        _attack = GetComponentInChildren<ColliderAttack>();
    }

    private void OnMovement(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
        //Debug.Log(movementInput);
        TriggerInputEvent();
    }

    private void TriggerInputEvent() => OnInputChanged?.Invoke(new PlayerInputData(
        movementInput, 
        isAttacking, 
        isScrollingLeft, 
        isScrollingRight,
        isPaused
        ));

    private void OnJump()
    {
        Debug.Log("Jump!");
        //TriggerInputEvent();
    }

    private void OnAttack()
    {
        Debug.Log("Attack!");

        TriggerInputEvent();
    }

    private void OnTakeItem()
    {
        Debug.Log("Pick Up Item!");
        // Взаимодействие с CharacterPickUpItems
        //pickUpItems.PickUpItem();
    }

    private void OnUseItem()
    {
        Debug.Log("Use Item!");
        // Логика использования предмета
    }

    private void OnFirstSpecAttack()
    {
        Debug.Log("Special Attack Left!");
        // Логика для специальной атаки
    }

    private void OnSecondSpecAttack()
    {
        Debug.Log("Special Attack Right!");
        // Логика для специальной атаки
    }
    
    private void OnScrollLeft()
    {
        //Debug.Log("Scroll Left!");
        isScrollingLeft = true;
        TriggerInputEvent();
        isScrollingLeft = false;
    }
    
    private void OnScrollRight()
    {
        //Debug.Log("Scroll Right!");
        isScrollingRight = true;
        TriggerInputEvent();
        isScrollingRight = false;
    }
    
    private void OnPause()
    {
        isPaused = true;
        TriggerInputEvent();
        isPaused = false;
    }
}
