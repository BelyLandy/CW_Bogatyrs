using System.Collections.Generic;
using UnityEngine;

public class PlayerScrollItems : MonoBehaviour
{
    private PlayerInputHandler inputHandler;

    private void Awake()
    {
        inputHandler = GetComponent<PlayerInputHandler>();
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
        if (inputData.IsScrollingLeft)
        {
            ScrollLeft();
        }
        if (inputData.IsScrollingRight)
        {
            ScrollRight();
        }
    }

    private void ScrollLeft()
    {
        Debug.Log("Scroll Left!");
    }
    
    private void ScrollRight()
    {
        Debug.Log("Scroll Right!");
    }
    
}
