using System.Collections;
using UnityEngine;

public class TrialEffect : MonoBehaviour {
    private LineRenderer lineRenderer;
    private Player player;
    [SerializeField] private float moveSpeedNotMoving;
    [SerializeField] private float moveSpeedMoving;
    [SerializeField] private float comeBackSpeed;

    private void Awake() {
        GetComponents();
    }

    private void Start() {
        StartCoroutine(MakeTrial());
    }

    private void GetComponents() {
        lineRenderer = GetComponent<LineRenderer>();
        player = GetComponent<Player>();
    }

    private IEnumerator MakeTrial() {
        Vector3 moveVector;
        while (true) {
            Vector3 playerPos = transform.position;

            // Player is moving
            moveVector = new Vector3(moveSpeedMoving * player.movementVector.x, 0, 0);

            // Player is not moving
            if (player.movementVector == Vector2.zero) {
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
