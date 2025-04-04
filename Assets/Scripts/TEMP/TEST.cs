using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TEST : MonoBehaviour
{
    private Transform _player;

    private Rigidbody2D _r;
    
    private PlayerInput _input;

    private Vector2 moveInput;

    private float speed = 5f;
    
    void Awake()
    {
        //_player = GetComponent<Transform>();
        //_input = GetComponent<PlayerInput>();
        //_input.actions["Movement"].ReadValue<Vector2>();
    }

    public void OnMovementTest(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }
    
    void Update()
    {

    }

    void MovementLogic()
    {
        float step = speed * Time.deltaTime;
        
        if (moveInput.x != 0)
        {
            _player.position = Vector2.MoveTowards(_player.position, moveInput, step);
        }
    }
    
}