using System.Collections;
using UnityEngine;

public class CreateLevel : MonoBehaviour {
    public static CreateLevel instance;
    [SerializeField] private Level level;
    private float spawnObstacleDelay;
    private IEnumerator CreatObstaclesCoroutine;
    private Vector2 obstacleSpawnPoint;

    private void Awake() {
        if (instance != null) {
            Destroy(this);
        }
        instance = this;
    }

    private void Start() {
        SetObstaclesSpawnPoint();

        if (LevelManager.instance != null) {
            level = LevelManager.instance.GetChosenLevel();
        }

        spawnObstacleDelay = level.GetSpawnObstacleDelay();
        StartCreatObstaclesCoroutine();
    }

    private void SetObstaclesSpawnPoint() {
        Vector2 screenBorders = 
            Helpers.CameraHelper.GetCameraBordersWorldPosition();
        obstacleSpawnPoint = new Vector2(screenBorders.x + 3, 0);
    }

    public void StartCreatObstaclesCoroutine() {
        CreatObstaclesCoroutine = CreatObstacles();
        StartCoroutine(CreatObstaclesCoroutine);
    }

    public IEnumerator CreatObstacles() {

        if (level == null) yield return null;

        yield return new WaitForSeconds(spawnObstacleDelay);

        int randomObstacle = Random.Range(0, level.GetObstacles().Count);

        GameObject newObstacle = Instantiate(
            level.GetObstacles()[randomObstacle], transform
        );

        newObstacle.transform.localPosition = obstacleSpawnPoint;

    }
}
