using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IDamageable {
    [SerializeField] private int health;
    [SerializeField] private float speed;
    [SerializeField] private float jumpingForce;
    private Vector2 movementVector;
    private Rigidbody2D rb;
    private bool isJumping; 

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        rb.velocity = new Vector2(movementVector.x * speed, rb.velocity.y);

        if (isJumping && Mathf.Abs(rb.velocity.y) < 0.01f) {
            rb.AddForce(Vector2.up * jumpingForce, ForceMode2D.Impulse);
        }
    }

    public void Damage(int value) {
        health -= value;
        if (health < 1) {
            Destroy(gameObject);
        }
    }

    public void Move(InputAction.CallbackContext context) {
        movementVector = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context) {
        if (context.performed) {
            isJumping = true;
        }

        if (context.canceled) {
            isJumping = false;
        }
    }
}
