
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IDamageable {
    [SerializeField] private int health;
    [SerializeField] private float speed;
    [SerializeField] private float jumpingForce;
    private Vector2 movementVector;
    private Rigidbody2D rb;
    private bool isJumping;
    private bool isGrounded;
    private ParticleSystem cubeDiedParticles;
    private SpriteRenderer spriteRenderer;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        cubeDiedParticles = GetComponent<ParticleSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isGrounded = true;
    }

    private void Update() {
        rb.velocity = new Vector2(movementVector.x * speed, rb.velocity.y);

        if (isJumping && Mathf.Abs(rb.velocity.y) < 0.01f && isGrounded) {
            rb.AddForce(Vector2.up * jumpingForce, ForceMode2D.Impulse);
        }
    }

    public void Damage(int value) {
        health -= value;
        if (health < 1) {
            spriteRenderer.enabled = false;
            cubeDiedParticles.Play();
            CustomEvent.instance.PlayerDie();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        Vector2 collisionNormal = collision.contacts[0].normal;
        if (collisionNormal.y > 0) {
            isGrounded = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.contacts.Length == 0) {
            isGrounded = false;
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