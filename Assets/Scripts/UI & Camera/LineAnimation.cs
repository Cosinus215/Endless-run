using System.Collections;
using UnityEngine;

public class LineAnimation : MonoBehaviour {
    private LineRenderer lineRenderer;
    [SerializeField] private float wavelength;
    [SerializeField] private float amplitude;
    [SerializeField] private float waveSpeed;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start() {
        StartCoroutine(LineMove(new Vector3(-30, 0, 0)));
    }

    IEnumerator LineMove(Vector3 startPoint) {
        Vector3 newPos2 = Vector3.zero;
        while (true) {
            float x = 0f;
            float y;
            float k = 2 * Mathf.PI / wavelength;
            float w = k * waveSpeed;
            lineRenderer.positionCount = 100;
            for (int i = 0; i < lineRenderer.positionCount; i++) {
                x += i * 0.001f;
                y = amplitude * Mathf.Sin(k * x + w * Time.time);
                lineRenderer.SetPosition(i, new Vector3(x, y, 0) + startPoint + newPos2);
            }
            newPos2 += new Vector3(0.02f, 0, 0);

            if (lineRenderer.GetPosition(0).x > 10) {
                newPos2 = Vector3.zero;
            }

            yield return null;
        }

    }
}
