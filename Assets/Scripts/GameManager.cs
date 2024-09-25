using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    [SerializeField] private GameObject borderPrefab;
    [SerializeField] private GameObject obstacleBorderPrefab;

    private void Awake() {
        if (instance != null) {
            Destroy(this);
        }
        instance = this;
    }

    private void Start() {
        SetUpBorders();
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
}
