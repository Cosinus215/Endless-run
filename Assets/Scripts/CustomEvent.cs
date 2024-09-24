using System;
using UnityEngine;

public class CustomEvent : MonoBehaviour {
    public static CustomEvent instance;

    private void Awake() {
        instance = this;
    }

    public event Action onPlayerDie;
    public void PlayerDie() {
        if (onPlayerDie != null) {
            onPlayerDie();
        }
    }
}
