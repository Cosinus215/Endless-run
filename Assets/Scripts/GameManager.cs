using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public int points;
    [SerializeField] private GameObject borderPrefab;
    [SerializeField] private GameObject obstacleBorderPrefab;
    private Coroutine PointsCounter;

    private void Awake() {
        if (instance != null) {
            Destroy(this);
        }
        instance = this;
    }

    private void Start() {
        SetUpBorders();
        CustomEvent.instance.onPlayerDie += StopCountingPoints;
        PointsCounter = StartCoroutine(PointsCounterCoroutin());
    }

    public void StopCountingPoints() {
        StopCoroutine(PointsCounter);
    }

    private void SetUpBorders() {
        Vector2 screenBorders = 
            Helpers.CameraHelper.GetCameraBordersWorldPosition();

        for (float i = -1; i < 2; i += 2) {
            GameObject border = Instantiate(borderPrefab);

            border.transform.position = new Vector2((screenBorders.x * i) + i, 0);
        }
        GameObject obstaclesBorder = Instantiate(obstacleBorderPrefab);
    }

    private IEnumerator PointsCounterCoroutin() {
        while (true) {
            points++;
            yield return new WaitForSeconds(1);
        }
    }
}
