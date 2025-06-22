using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveDir;
    private Rigidbody2D rb;
    [SerializeField] private float _spead = 3;

    private PlayerInputActions actionMap;
    private InputAction moveAct;
    public float Speed
    {
        get => _spead;
        set => _spead = Mathf.Clamp(value, 1, 50);
    }

    void Start()
    {
        actionMap = new PlayerInputActions();
        moveAct = actionMap.Player.Move;
        moveAct.Enable();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveDir = moveAct.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if (moveDir != Vector2.zero)
        {
            rb.linearVelocity = moveDir * Speed;
        }
    }
}
