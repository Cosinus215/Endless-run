using System.Collections;
using UnityEngine;

public class TrialEffect : MonoBehaviour {
    private LineRenderer lineRenderer;
    private Player player;
    private Vector3 moveVector;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float comeBackSpeed;

    private void Awake() {
        GetComponents();
    }

    private void Start() {
        SetUpMoveVector();
        StartCoroutine(MakeTrial());
    }

    private void GetComponents() {
        lineRenderer = GetComponent<LineRenderer>();
        player = GetComponent<Player>();
    }

    private void SetUpMoveVector() {
        moveVector = new Vector3(moveSpeed, 0, 0);
    }

    private IEnumerator MakeTrial() {
        while (true) {
            if (lineRenderer.positionCount > 30) {
                DeleteFirstPos();
            }

            Vector3 playerPos = transform.position;

            // Player is not moving
            if (player.movementVector == Vector2.zero) {
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

            // Player is moving
            if (lineRenderer.GetPosition(lineRenderer.positionCount - 1) != playerPos) {
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, playerPos);
            }
            yield return null;
        }
    }


    private void DeleteFirstPos() {
        Vector3[] newPositions = new Vector3[lineRenderer.positionCount - 1];

        for (int i = 1; i < lineRenderer.positionCount; i++) {
            newPositions[i - 1] = lineRenderer.GetPosition(i);
        }

        lineRenderer.positionCount = newPositions.Length;
        lineRenderer.SetPositions(newPositions);
    }
}
