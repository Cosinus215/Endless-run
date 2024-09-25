using UnityEngine;

public class Border : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.TryGetComponent(out IDestroyable iDestroyable)) {
            iDestroyable.DestroyObject();
        }

        if (collision.TryGetComponent(out IDamageable iDamage)) {
            iDamage.Damage(1);
        }
    }
}
