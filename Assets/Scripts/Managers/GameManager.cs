using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    [SerializeField] private GameObject borderPrefab;
    [SerializeField] private float speedMultiplier;
    [SerializeField] private GameObject obstacleBorderPrefab;

    private void Awake() {
        if (instance != null) {
            Destroy(this);
        }
        instance = this;
    }

    private void Start() {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
        SetUpBorders();
    }

    private void SetUpBorders() {
        Vector2 screenBorders = 
            Helpers.CameraHelper.GetCameraBordersWorldPosition();

        for (float i = -1; i < 2; i += 2) {
            GameObject border = Instantiate(borderPrefab);

            border.transform.position = new Vector2((screenBorders.x * i) + i, 0);
        }
        Instantiate(obstacleBorderPrefab);
    }

    public float GetSpeedMultiplier() {
        return speedMultiplier;
    }
}
