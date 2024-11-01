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

        // Loop to create borders on both sides of the screen
        for (float i = -1; i < 2; i += 2) {
            // Instantiate a border prefab
            GameObject border = Instantiate(borderPrefab); 
            
            // Position the border at the edge of the screen
            border.transform.position = new Vector2((screenBorders.x * i) + i, 0);
        }

        // Instantiate the border prefab for obstacles
        Instantiate(obstacleBorderPrefab);
    }

    public float GetSpeedMultiplier() {
        return speedMultiplier;
    }
}
