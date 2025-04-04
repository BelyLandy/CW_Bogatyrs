using UnityEngine;

public struct PlayerInputData
{
    private Vector2 movementInput;
    private bool isAttacking;
    private bool isScrollingLeft;
    private bool isScrollingRight;
    private bool isPaused;

    public PlayerInputData(
        Vector2 _movementInput, 
        bool _isAttacking = false, 
        bool _isScrollingLeft = false, 
        bool _isScrollingRight = false, 
        bool _isPaused = false)
    {
        movementInput = _movementInput;
        isAttacking = _isAttacking;
        isScrollingLeft = _isScrollingLeft;
        isScrollingRight = _isScrollingRight;
        isPaused = _isPaused;
    }
    
    public Vector2 MovementInput => movementInput;
    public bool IsAttacking => isAttacking;
    public bool IsScrollingLeft => isScrollingLeft;
    public bool IsScrollingRight => isScrollingRight;
    public bool IsPaused => isPaused;
}