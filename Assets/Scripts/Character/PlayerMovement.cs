using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField, Tooltip("Max speed, in units per second, that the character moves.")]
    [SerializeField] private float speed = 2.5f;
    
    [SerializeField] private float walkAcceleration = 75;
    
    [SerializeField] private float groundDeceleration = 75;
    
    //[SerializeField] private float airAcceleration = 30;
    
    //[SerializeField] private float jumpHeight = 4;

    [SerializeField] private bool slipperyMovement = false;

    private Rigidbody2D rb;
    
    private Vector2 velocity;

    private Vector2 movementInput;

    private PlayerInputHandler inputHandler;

    private bool isMovementPressed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
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
        movementInput = inputData.MovementInput;
        TurnPlayer();
    }
    
    private void FixedUpdate()
    {
        DoPlayerMovement();
    }

    private void TurnPlayer()
    {
        if (movementInput.x < 0)
        {
            transform.rotation = new Quaternion(0, -180, 0,0);
            //Debug.Log("-180");
        }
        else if (movementInput.x > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            //Debug.Log("0");
        }
    }
    
    /// <summary>
    /// Обрабатывает движение персонажа.
    /// </summary>
    private void DoPlayerMovement()
    {
        Vector2 direction = movementInput.normalized;
        Vector2 targetVelocity = direction * speed;

        Vector2 newVelocity = rb.linearVelocity;

        // Горизонтальное движение
        if (movementInput.x != 0)
        {
            newVelocity.x = slipperyMovement
                ? Mathf.MoveTowards(rb.linearVelocity.x, targetVelocity.x, walkAcceleration * Time.fixedDeltaTime)
                : targetVelocity.x;
        }
        else
        {
            newVelocity.x = slipperyMovement
                ? Mathf.MoveTowards(rb.linearVelocity.x, 0, groundDeceleration * Time.fixedDeltaTime)
                : 0;
        }

        // Вертикальное движение
        if (movementInput.y != 0)
        {
            newVelocity.y = slipperyMovement
                ? Mathf.MoveTowards(rb.linearVelocity.y, targetVelocity.y, walkAcceleration * Time.fixedDeltaTime)
                : targetVelocity.y;
        }
        else
        {
            newVelocity.y = slipperyMovement
                ? Mathf.MoveTowards(rb.linearVelocity.y, 0, groundDeceleration * Time.fixedDeltaTime)
                : 0;
        }

        rb.linearVelocity = newVelocity;
    }
}
