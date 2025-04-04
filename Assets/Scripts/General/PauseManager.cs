using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    private PlayerInputHandler inputHandler;
    
    private bool isPaused = false;

    private PlayerAnimController _playerAnimController;
    private PlayerMovement _playerMovement;
    
    
    private PlayerInput _playerInput;
    
    private void Awake()
    {
        inputHandler = GetComponent<PlayerInputHandler>();
        _playerAnimController = GetComponent<PlayerAnimController>();
        _playerInput = GetComponent<PlayerInput>();
        _playerMovement = GetComponent<PlayerMovement>();
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
        if (inputData.IsPaused)
        {
            TogglePause();
        }
    }
    
    private void TogglePause()
    {
        isPaused = !isPaused;
        Debug.Log(isPaused ? "Paused!" : "Unpaused!");

        //_playerAnimController.enabled = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
        _playerInput.SwitchCurrentActionMap(isPaused ? "UI" : "Player");
        //_playerMovement.enabled = !isPaused;

        // Если есть UI для паузы, можно его включать/выключать:
        // pauseMenu.SetActive(isPaused);
    }

}