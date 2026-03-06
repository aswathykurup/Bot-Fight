using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputSystem_Actions playerInput;
    Rigidbody rb;
    public float JumpForce = 100f;
    public float moveSpeed = 5f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Vector3 offset;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = new InputSystem_Actions();

        playerInput.Player.Jump.performed += OnJump;
        playerInput.Player.Attack.performed += OnAttack;
        playerInput.Player.Pause.performed += OnPause;

    }
    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
        playerInput.Player.Jump.performed -= OnJump;
        playerInput.Player.Attack.performed -= OnAttack;
        playerInput.Player.Pause.performed -= OnPause;

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = playerInput.Player.Move.ReadValue< Vector2>();
        Vector3 movement = new Vector3 (inputVector.x,0f,inputVector.y);
        transform.Translate(movement * moveSpeed *  Time.deltaTime , Space.World);

    }

    private void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump button was pressed!");
        rb.AddForce(0, JumpForce, 0);

    }
    private void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log("Attack button was pressed!");
        Instantiate(bullet,transform.position + offset, Quaternion.identity);

    }
    private void OnPause(InputAction.CallbackContext context)
    {
        ScoreManager.Instance.PauseGame();

    }
}
    
