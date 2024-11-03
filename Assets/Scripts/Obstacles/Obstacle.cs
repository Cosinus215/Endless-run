using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour, IDestroyable {
    [SerializeField] private int damage;
    [SerializeField] private ObstacleEffect obstacleEffect;
    [SerializeField] private float speed;
    private float speedMultiplier;

    private void Start() {
        CustomEvent.instance.onPlayerDie += StartToSlowDown;
    }

    private void Update() {
        speedMultiplier = GameManager.instance.GetSpeedMultiplier();
        transform.position = 
            new Vector2(
                transform.position.x - (0.12f * speed * speedMultiplier * Time.deltaTime), 
                transform.position.y
            );
    }

    private void OnDestroy() {
        CustomEvent.instance.onPlayerDie -= StartToSlowDown;
    }

    public void DestroyObject() {       
        Destroy(gameObject); 
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
        while (GameManager.instance.GetSpeedMultiplier() > 0) {
            float newSpeedMultiplier = GameManager.instance.GetSpeedMultiplier();
            GameManager.instance.SetSpeedMultiplier(
                Mathf.MoveTowards(newSpeedMultiplier, 0f, 0.1f * Time.deltaTime)
            );

            yield return null;
        }
    }
}
