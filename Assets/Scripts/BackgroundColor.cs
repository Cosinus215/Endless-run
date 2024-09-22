using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColor : MonoBehaviour {
    [SerializeField] private float hueChangeSpeed = 0.1f;
    private float hue;

    private void FixedUpdate() {
        ChangeHue();
        UpdateBackgroundColor();
    }

    private void ChangeHue() =>
        hue = (hue + hueChangeSpeed * Time.fixedDeltaTime) % 1f;


    private void UpdateBackgroundColor() {
        Color backgroundColor = Color.HSVToRGB(hue, 0.38f, 0.50f);
        Camera.main.backgroundColor = backgroundColor;
    }
}
