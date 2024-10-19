using System;
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Player : MonoBehaviour, IDamageable {
    [SerializeField] private int health;
    [SerializeField] private float speed;
    [SerializeField] private float jumpingForce;
    [SerializeField] private Volume globalVolume;
    [SerializeField] private GameObject endGamePanel;
    private int finalRotation;
    public Vector2 movementVector;
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

    private void FixedUpdate() {
        rb.velocity = new Vector2(movementVector.x * speed * Time.fixedDeltaTime, rb.velocity.y);

        if (isJumping && Mathf.Abs(rb.velocity.y) < 0.01f && isGrounded) {
            StartCoroutine(RotatePlayer());
            rb.AddForce(Vector2.up * jumpingForce, ForceMode2D.Impulse);
            //Debug.Log("JUMP");
        }
    }

    public void Damage(int value) {
        health -= value;
        if (health < 1) {
            spriteRenderer.enabled = false;
            cubeDiedParticles.Play();
            EnableEndGameUI();
            CustomEvent.instance.PlayerDie();
        }
    }

    private void EnableEndGameUI() {
        globalVolume.enabled = true;
        endGamePanel.SetActive(true);
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

    private IEnumerator RotatePlayer() {
        finalRotation += 90;
        if (finalRotation == 270) finalRotation = -90;

        Quaternion newRotation = Quaternion.Euler(0, 0, -finalRotation);
        float speed = 0.7f;
        float timeCount = 0.0f;

        while (transform.rotation != newRotation) {
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, timeCount * speed);
            timeCount = timeCount + Time.deltaTime;
            yield return null;
        }
        transform.rotation = newRotation;
    }
}