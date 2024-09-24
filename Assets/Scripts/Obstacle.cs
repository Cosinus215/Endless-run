using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    [SerializeField] private int damage;
    [SerializeField] private ObstacleEffect obstacleEffect;
    [SerializeField] private float speed;

    private void Start() {
        speed = 1;
        transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y);
        CustomEvent.instance.onPlayerDie += StartToSlowDown;
    }

    private void FixedUpdate() {
        transform.position = new Vector2(transform.position.x - 0.12f * speed, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.TryGetComponent(out IDamageable iDamage)) {
            iDamage.Damage(damage);

            if (obstacleEffect == null) return;
            obstacleEffect.ApplyEffect(collision.gameObject);
        }
    }

    private void StartToSlowDown() {
        StartCoroutine(SlowDown());
    }

    private IEnumerator SlowDown() {
        while (speed > 0) {
            speed = Mathf.MoveTowards(speed, 0f, 0.5f * Time.deltaTime);
            yield return null;
        }
    }
}
