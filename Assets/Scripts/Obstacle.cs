using UnityEngine;

public class Obstacle : MonoBehaviour {
    [SerializeField] private int damage;

    private void Update() {
        transform.position = new Vector2(transform.position.x - 0.01f, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.TryGetComponent(out IDamageable iDamage)) {
            iDamage.Damage(damage);
        }
    }
}
