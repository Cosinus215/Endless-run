using UnityEngine;

public class Border : MonoBehaviour {
    [SerializeField] private bool isForPlayer;
    private bool isRightSide;

    private void Start() {
        CustomEvent.instance.onPlayerDie += DestroyBorder;
    }

    private void DestroyBorder() {
        if (TryGetComponent(out BoxCollider2D c))
            c.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) { 
        if (collision.TryGetComponent(out IDestroyable iDestroyable)) {
            if (isRightSide) {
                CreateLevel.instance.StartCreatObstaclesCoroutine();
                return;
            }

            if (isForPlayer) return;
            iDestroyable.DestroyObject();
        }

        if (collision.TryGetComponent(out IDamageable iDamage)) {
            iDamage.Damage(1);
        }
    }

    public void SetIsRightSide(bool value) {
        isRightSide = value;    
    }
}
