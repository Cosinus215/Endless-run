using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrialEffect : MonoBehaviour {
    [SerializeField] private SpriteRenderer playerBackground;
    [SerializeField] private float colorSwitchSpeed;
    [SerializeField] private float alphaEnd;
    [SerializeField] private float moveSpeedNotMoving;
    [SerializeField] private float moveSpeedMoving;
    [SerializeField] private float comeBackSpeed;
    private LineRenderer lineRenderer;
    private Player player;
    private Color lineColor;
    private float color;

    private void Awake() {
        GetComponents();
    }

    private void Start() {
        StartCoroutine(MakeTrial());
        StartCoroutine(ChangeTrailColors());
    }

    private void GetComponents() {
        lineRenderer = GetComponent<LineRenderer>();
        player = GetComponent<Player>();
    }

    private void CreateGradientKeys(out GradientAlphaKey[] gradientAlphas,
        out List<GradientColorKey> gradientColors) {
        GradientAlphaKey startAlpha = new(1, 0.0f);
        GradientAlphaKey endAlpha = new(alphaEnd / 255, 1.0f);
        gradientAlphas = new[]{ startAlpha, endAlpha };

        gradientColors = new();
    }

    private IEnumerator ChangeTrailColors() {
        Gradient gradient = new();
        CreateGradientKeys(
            out GradientAlphaKey[] gradientAlphas,
            out List<GradientColorKey> gradientColors
        );

        while (true) {
            color = (color + colorSwitchSpeed * Time.deltaTime) % 1f;
            lineColor = Color.HSVToRGB(color, 1f, 1f);
            playerBackground.color = lineColor;

            GradientColorKey trialColor = new(lineColor, 0.0f);
            gradientColors.Clear();
            gradientColors.Add(trialColor);

            gradient.SetKeys(gradientColors.ToArray(), gradientAlphas);

            lineRenderer.colorGradient = gradient;
            yield return null;
        }
    }


    private IEnumerator MakeTrial() {
        Vector3 moveVector;
        while (true) {
            Vector3 playerPos = transform.position;

            // Player is moving
            moveVector = new Vector3(moveSpeedMoving * player.GetMovementVector().x, 0, 0);

            // Player is not moving
            if (player.GetMovementVector() == Vector2.zero) {
                moveVector = new Vector3(moveSpeedNotMoving, 0, 0);
            }

            lineRenderer.SetPosition(lineRenderer.positionCount - 1, playerPos);
            for (int i = lineRenderer.positionCount - 2; i >= 0; i--) {
                Vector3 targetPos = lineRenderer.GetPosition(i + 1) - moveVector;
                Vector3 newPos = Vector3.Lerp(
                    lineRenderer.GetPosition(i),
                    targetPos,
                    Time.deltaTime * comeBackSpeed
                );

                lineRenderer.SetPosition(i, newPos);
            }
            yield return null;
        }
    }
}