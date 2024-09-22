using UnityEngine;

public class Player : MonoBehaviour, IDamageable {
    public int health;

    public void Damage(int value) {
        health -= value;
        if (health < 1) {
            Destroy(gameObject);
        }
    }
}
