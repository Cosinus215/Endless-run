using System.Collections;
using UnityEngine;

public class ObstacleAnimation : MonoBehaviour {

    private enum AnimationType {
        ArcRotation
    }

    [SerializeField] private AnimationType animationType;
    [SerializeField] private float speed;
    [SerializeField] private float rotationAngle;
    
    private void Start() {
        ApplyAnimation();
    }

    public void ApplyAnimation() {
        switch (animationType) {
            case AnimationType.ArcRotation:
                StartCoroutine(ArcRotationCoroutine());
                break;
        }
    }

    public IEnumerator ArcRotationCoroutine() {
        float time = 0f;

        while (true) {
            float easedAngle = Mathf.Sin(time) * rotationAngle;
            transform.rotation = Quaternion.Euler(0, 0, easedAngle);

            time += speed * Time.deltaTime;
            if (time >= Mathf.PI * 2) {
                time -= Mathf.PI * 2;
            }

            yield return null;
        }
    }



}
