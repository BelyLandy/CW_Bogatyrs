// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;
// using UnityEngine;
// using UnityEngine.InputSystem;
//
// [RequireComponent(typeof(BoxCollider2D))]
// public class CharacterController2D : MonoBehaviour
// {
//     [SerializeField, Tooltip("Max speed, in units per second, that the character moves.")]
//     float speed = 90;
//
//     [SerializeField, Tooltip("Acceleration while grounded.")]
//     float walkAcceleration = 75;
//
//     // [SerializeField, Tooltip("Acceleration while in the air.")]
//     // float airAcceleration = 30;
//
//     [SerializeField, Tooltip("Deceleration applied when character is grounded and not attempting to move.")]
//     float groundDeceleration = 75;
//
//     // [SerializeField, Tooltip("Max height the character will jump regardless of gravity")]
//     // float jumpHeight = 4;
//
//     //private BoxCollider2D boxCollider;
//
//     private Vector2 velocity;
//
//     private Rigidbody2D rb;
//
//     private Animator CharacterAnimator;
//
//     private ColliderBaseAttack baseAttack;
//     private ColliderPickUpItems pickUpItems;
//
//     private InputAction jumpAction;
//     private InputAction baseAttackAction;
//     private InputAction pickUpItemAction;
//     private InputAction useItemAction;
//     private InputAction scrollItemLeftAction;
//     private InputAction scrollItemRightAction;
//     private InputAction specAttackLeftAction;
//     private InputAction specAttackRightAction;
//
//     private SpriteRenderer spriteRenderer;
//
//     private const string BASE_ATTACK = "Base_Attack";
//     private const string MOVEMENT = "Movement";
//     private const string DIAGONAL = "Diagonal";
//     private const string VERTOGONAL = "Vertogonal";
//
//     private const string SELECTED_CELL = "SELECTED_CELL";
//     private const string UNSELECTED_CELL = "UNSELECTED_CELL";
//     
//     private float speedMultiplier = 1.0f;
//     private float lastHorizontalPressTime = 0f;
//     private float doublePressDelay = 0.3f; // Максимальный интервал для двойного нажатия
//     private float lastMoveDirection = 0f; // Направление последнего нажатия (-1 или 1)
//     private float tolerance = 0.1f; // Погрешность для определения направления
//     private bool isFastMoving = false; // Указывает, происходит ли ускоренное движение
//
//     private PlayerInputActions input;
//
//     private Vector2 movementInput;
//     
//     private void Awake()
//     {
//         rb = GetComponent<Rigidbody2D>();
//         //boxCollider = GetComponent<BoxCollider2D>();
//
//         input = new PlayerInputActions();
//
//         input.Player_1.Movement.performed += ctx => Debug.Log(ctx.ReadValueAsObject());
//         
//         // jumpAction = input.actions["Player_1/Jump"];
//         // baseAttackAction = input.actions["Player_1/BaseAttack"];
//         // pickUpItemAction = input.actions["Player_1/PickUpItem"];
//         // useItemAction = input.actions["Player_1/UseItem"];
//         // scrollItemLeftAction = input.actions["Player_1/ScrollItemLeft"];
//         // scrollItemRightAction = input.actions["Player_1/ScrollItemRight"];
//         // specAttackLeftAction = input.actions["Player_1/SpecAttackLeft"];
//         // specAttackRightAction = input.actions["Player_1/SpecAttackRight"];
//         //prefab = Resources.Load<GameObject>("Prefabs/BelenaWithAnim");
//         CharacterAnimator = GetComponent<Animator>();
//
//         spriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
//
//         baseAttack = GetComponentInChildren<ColliderBaseAttack>();
//         pickUpItems = GetComponentInChildren<ColliderPickUpItems>();
//     }
//
//     private void OnEnable()
//     {
//         input.Player_1.Enable();
//         
//         jumpAction.performed += PerformJump;
//         baseAttackAction.performed += PerformBaseAttack;
//         pickUpItemAction.performed += PerformPickUpItem;
//         useItemAction.performed += PerformUseItem;
//         scrollItemLeftAction.performed += PerformScrollItemLeft;
//         scrollItemRightAction.performed += PerformScrollItemRight;
//         specAttackLeftAction.performed += PerformSpecAttackLeft;
//         specAttackRightAction.performed += PerformSpecAttackRight;
//
//
//         baseAttack.OnBaseAttack += HandleBaseAttack;
//         pickUpItems.OnPickUpItems += HandleOnPickUpItems;
//     }
//
//     private void OnDisable()
//     {
//         input.Player_1.Disable();
//         
//         jumpAction.performed -= PerformJump;
//         baseAttackAction.performed -= PerformBaseAttack;
//         pickUpItemAction.performed -= PerformPickUpItem;
//         useItemAction.performed -= PerformUseItem;
//         scrollItemLeftAction.performed -= PerformScrollItemLeft;
//         scrollItemRightAction.performed -= PerformScrollItemRight;
//         specAttackLeftAction.performed -= PerformSpecAttackLeft;
//         specAttackRightAction.performed -= PerformSpecAttackRight;
//
//
//         baseAttack.OnBaseAttack -= HandleBaseAttack;
//         pickUpItems.OnPickUpItems -= HandleOnPickUpItems;
//     }
//
//     private List<GameObject> baseAttackObjects = new();
//     private List<GameObject> pickUpItemObjects = new();
//
//     private GameObject pickUpObject;
//
//     private void HandleBaseAttack(Collider other, bool isEntering)
//     {
//         // Если объект входит в триггер и он еще не добавлен в список
//         if (isEntering)
//         {
//             if (!baseAttackObjects.Contains(other.gameObject))
//             {
//                 baseAttackObjects.Add(other.gameObject);
//             }
//         }
//         else
//         {
//             baseAttackObjects.Remove(other.gameObject);
//         }
//
//         Debug.Log("Current objects in trigger: " + baseAttackObjects.Count);
//     }
//
//     private List<string> allowedTags = new List<string> { "BelenaPlant", "Enemy", "Obstacle", "BelenaItem", "Repka_Plant", "Repka_Item" };
//
//     private void PerformBaseAttack(InputAction.CallbackContext context)
//     {
//         if (baseAttackObjects.Count == 0)
//         {
//             Debug.Log("No valid Base Attack Objects!");
//             return;
//         }
//
//         // Получаем и фильтруем список объектов, которые соответствуют допустимым тегам
//         var validTargets = baseAttackObjects
//             .Where(obj => obj != null && allowedTags.Contains(obj.tag))
//             .ToList();
//
//         if (validTargets.Count == 0)
//         {
//             Debug.Log("No valid targets found!");
//             return;
//         }
//
//         // Обрабатываем атаку для каждого подходящего объекта
//         foreach (var target in validTargets)
//         {
//             HandleAttackOnObject(target);
//         }
//
//         // Удаляем обработанные объекты из основного списка
//         baseAttackObjects = baseAttackObjects
//             .Except(validTargets)
//             .ToList();
//     }
//
//     private void HandleAttackOnObject(GameObject targetObject)
//     {
//         Transform spriteTransform = targetObject.transform.Find("Sprite");
//         Renderer spriteRenderer = spriteTransform != null ? spriteTransform.GetComponent<Renderer>() : null;
//                 
//         if (spriteRenderer != null)
//         {
//             spriteRenderer.enabled = false;
//         }
//         else
//         {
//             Debug.LogWarning("Sprite object not found or Renderer is missing!");
//         }
//                 
//         Collider objectCollider = targetObject.GetComponent<Collider>();
//         if (objectCollider != null)
//         {
//             objectCollider.enabled = false;
//         }
//         else
//         {
//             Debug.LogWarning("Collider not found on object!");
//         }
//         
//         // Ищем компонент PrefabHolder и получаем префаб
//         var prefabHolder = targetObject.GetComponent<PrefabHolder>();
//
//         if (prefabHolder != null && prefabHolder.associatedPrefab != null)
//         {
//             // Создаем префаб в позиции объекта
//             Instantiate(prefabHolder.associatedPrefab, targetObject.transform.position, Quaternion.identity);
//         }
//         else
//         {
//             Debug.LogError($"Prefab not found on object: {targetObject.name}");
//         }
//         
//         var dropSoundObject = targetObject.transform.Find("DropSound");
//         if (dropSoundObject != null)
//         {
//             var audioSource = dropSoundObject.GetComponent<AudioSource>();
//             if (audioSource != null && audioSource.clip != null)
//             {
//                 StartCoroutine(HideAndPlaySound(audioSource, targetObject));
//             }
//             else
//             {
//                 Debug.LogError("AudioSource or clip not found on DropSound object!");
//                 Destroy(targetObject); // Если аудио нет, сразу уничтожаем объект
//             }
//         }
//         else
//         {
//             Debug.LogError("DropSound object not found on target!");
//             Destroy(targetObject); // Если нет объекта DropSound, сразу уничтожаем объект
//         }
//     }
//
//     private IEnumerator HideAndPlaySound(AudioSource audioSource, GameObject objectToDestroy)
//     {
//         audioSource.Play();
//         
//         yield return new WaitWhile(() => audioSource.isPlaying);
//         
//         Destroy(objectToDestroy);
//     }
//
//     //private GameObject onPickUpItemsObject;
//
//     private void HandleOnPickUpItems(Collider other, bool isEntering)
//     {
//         if (isEntering)
//         {
//             // pickUpObject = other.gameObject;
//             //
//             // Debug.Log("PickUp Object" + pickUpObject.name + " was wrote in");
//             
//             if (!pickUpItemObjects.Contains(other.gameObject))
//             {
//                 pickUpItemObjects.Add(other.gameObject);
//             }
//         }
//         else
//         {
//             // pickUpObject = null;
//             //
//             // Debug.Log("Last Pick Up Object was wrote out");
//              
//             pickUpItemObjects.Remove(other.gameObject);
//         }
//
//         //Debug.Log("Current objects in trigger Pick Up: " + pickUpItemObjects.Count);
//     }
//
//     private void PerformJump(InputAction.CallbackContext context)
//     {
//         Debug.Log("Jump!");
//     }
//
//     private void PerformPickUpItem(InputAction.CallbackContext context)
//     {
//         if (pickUpItemObjects.Count == 0)
//         {
//             Debug.Log("No valid Pick Up Objects!");
//             return;
//         }
//
//         // Получаем и фильтруем список объектов, которые соответствуют допустимым тегам
//         var validTargets = pickUpItemObjects
//             .Where(obj => obj != null && allowedTags.Contains(obj.tag))
//             .ToList();
//
//         if (validTargets.Count == 0)
//         {
//             Debug.Log("No valid targets found!");
//             return;
//         }
//
//         var lastTarget = validTargets.Last();
//         
//         // Обрабатываем последний объект
//         HandleOnPickUpItemsOnObject(lastTarget);
//
//         // Удаляем последний объект из списка
//         pickUpItemObjects.Remove(lastTarget);
//         
//     }
//
//     private void HandleOnPickUpItemsOnObject(GameObject targetObject)
//     {
//         Transform spriteTransform = targetObject.transform.Find("Sprite");
//         Renderer spriteRenderer = spriteTransform != null ? spriteTransform.GetComponent<Renderer>() : null;
//                 
//         if (spriteRenderer != null)
//         {
//             spriteRenderer.enabled = false;
//         }
//         else
//         {
//             Debug.LogWarning("Sprite object not found or Renderer is missing!");
//         }
//                 
//         Collider objectCollider = targetObject.GetComponent<Collider>();
//         if (objectCollider != null)
//         {
//             objectCollider.enabled = false;
//         }
//         else
//         {
//             Debug.LogWarning("Collider not found on object!");
//         }
//
//         var pickUpSoundObject = targetObject.transform.Find("PickUpSound");
//         if (pickUpSoundObject != null)
//         {
//             var audioSource = pickUpSoundObject.GetComponent<AudioSource>();
//             if (audioSource != null && audioSource.clip != null)
//             {
//                 StartCoroutine(HideAndPlaySound(audioSource, targetObject));
//             }
//             else
//             {
//                 Debug.LogError("AudioSource or clip not found on PickUpSound object!");
//                 Destroy(targetObject); // Если аудио нет, сразу уничтожаем объект
//             }
//         }
//         else
//         {
//             Debug.LogError("PickUpSound object not found on target!");
//             Destroy(targetObject); // Если нет объекта DropSound, сразу уничтожаем объект
//         }
//     }
//     
//     private void PerformUseItem(InputAction.CallbackContext context)
//     {
//         Debug.Log("Use Item!");
//     }
//
//     private void PerformScrollItemLeft(InputAction.CallbackContext context)
//     {
//         Debug.Log("Scroll Item Left!");
//         
//         
//     }
//
//     private void PerformScrollItemRight(InputAction.CallbackContext context)
//     {
//         Debug.Log("Scroll Item Right!");
//     }
//
//     private void PerformSpecAttackRight(InputAction.CallbackContext context)
//     {
//         Debug.Log("Spec Attack Right!");
//     }
//
//     private void PerformSpecAttackLeft(InputAction.CallbackContext context)
//     {
//         Debug.Log("Spec Attack Left!");
//     }
//
//     private void Update()
//     {
//         MirrorCharacter();
//     }
//
//     private void MirrorCharacter()
//     {
//         if (spriteRenderer != null)
//         {
//             if (moveInput.x < 0)
//             {
//                 spriteRenderer.flipX = true;
//             }
//             else if (moveInput.x > 0)
//             {
//                 spriteRenderer.flipX = false;
//             }
//         }
//
//         var baseAttackChild = transform.Find("BaseAttack");
//
//         if (baseAttackChild != null)
//         {
//             if (moveInput.x < 0)
//             {
//                 baseAttackChild.localRotation = Quaternion.Euler(0, 180, 0);
//             }
//             else if (moveInput.x > 0)
//             {
//                 baseAttackChild.localRotation = Quaternion.Euler(0, 0, 0);
//             }
//         }
//         
//         var pickUpChild = transform.Find("PickUpItems");
//
//         if (pickUpChild != null)
//         {
//             if (moveInput.x < 0)
//             {
//                 pickUpChild.localRotation = Quaternion.Euler(0, 180, 0);
//             }
//             else if (moveInput.x > 0)
//             {
//                 pickUpChild.localRotation = Quaternion.Euler(0, 0, 0);
//             }
//         }
//
//     }
//
//     private void FixedUpdate()
//     {
//         PlayerMovement();
//     }
//
//     private Vector2 moveInput;
//
//     private float elapsedTime = 0f;
//     private bool isTiming = false;
//
//     private float lastTriggerTime = -1f;
//
//     private void OnMovement(InputValue value)
//     {
//         Vector2 input = value.Get<Vector2>();
//         moveInput = input;
//         //Debug.Log(moveInput);
//     }
//
//     [SerializeField] private bool SlipperyMovement;
//     bool isRunning = false;
//
//     void PlayerMovement()
//     {
//         float inputCircle = Mathf.Sqrt(moveInput.x * moveInput.x + moveInput.y * moveInput.y);
//
//         Vector2 direction = moveInput.normalized;
//
//         Vector2 targetVelocity = direction * (speed * speedMultiplier);
//
//         Vector2 newVelocity = rb.linearVelocity;
//
//         //&& inputCircle > 0.5f && inputCircle <= 1f
//
//         //if (!isRunning)
//
//         if (moveInput.x != 0)
//         {
//             if (SlipperyMovement)
//             {
//                 newVelocity.x = Mathf.MoveTowards(rb.linearVelocity.x, targetVelocity.x,
//                     walkAcceleration * Time.fixedDeltaTime);
//             }
//             else
//             {
//                 newVelocity.x = targetVelocity.x;
//             }
//         }
//         else
//         {
//             if (SlipperyMovement)
//             {
//                 newVelocity.x = Mathf.MoveTowards(rb.linearVelocity.x, 0, groundDeceleration * Time.fixedDeltaTime);
//             }
//             else
//             {
//                 newVelocity.x = new Vector2(0f, 0f).x;
//             }
//         }
//
//         if (moveInput.y != 0)
//         {
//             if (SlipperyMovement)
//             {
//                 newVelocity.y = Mathf.MoveTowards(rb.linearVelocity.y, targetVelocity.y,
//                     walkAcceleration * Time.fixedDeltaTime);
//             }
//             else
//             {
//                 newVelocity.y = targetVelocity.y;
//             }
//         }
//         else
//         {
//             if (SlipperyMovement)
//             {
//                 newVelocity.y = Mathf.MoveTowards(rb.linearVelocity.y, 0, groundDeceleration * Time.fixedDeltaTime);
//             }
//             else
//             {
//                 newVelocity.y = new Vector2(0f, 0f).y;
//             }
//         }
//
//
//         rb.linearVelocity = newVelocity;
//     }
// }