using UnityEngine;

public class Obstacle : MonoBehaviour {
    [SerializeField] private int damage;
    [SerializeField] private ObstacleEffect obstacleEffect;

    private void Start() {
        transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y);
    }

    private void FixedUpdate() {
        transform.position = new Vector2(transform.position.x - 0.12f, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.TryGetComponent(out IDamageable iDamage)) {
            iDamage.Damage(damage);

            if (obstacleEffect == null) return;
            obstacleEffect.ApplyEffect(collision.gameObject);
        }
    }
}
