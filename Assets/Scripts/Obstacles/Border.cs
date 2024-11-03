using UnityEngine;

public class Border : MonoBehaviour {
    [SerializeField] private bool isForPlayer;
    private bool isRightSide;

    private void Start() {
        CustomEvent.instance.onPlayerDie += DestroyBorder;
    }

    private void DestroyBorder() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) { 
        if (collision.TryGetComponent(out IDestroyable iDestroyable)) {
            if (isRightSide) {
                //Debug.Log("SPAWN");
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
