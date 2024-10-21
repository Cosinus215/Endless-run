using System.Collections;
using UnityEngine;

public class CreateLevel : MonoBehaviour {
    [SerializeField] private Level level;
    private Coroutine CreatObstacles;
    private Vector2 obstacleSpawnPoint;

    private void Start() {
        SetObstaclesSpawnPoint();
        CustomEvent.instance.onPlayerDie += StopSpawningObstacles;

        if (LevelManager.instance == null) return;

        level = LevelManager.instance.GetChosenLevel();

        CreatObstacles = StartCoroutine(CreatObstaclesCoroutine());
    }

    private void SetObstaclesSpawnPoint() {
        Vector2 screenBorders = 
            Helpers.CameraHelper.GetCameraBordersWorldPosition();
        obstacleSpawnPoint = new Vector2(screenBorders.x + 3, 0);
    }

    private IEnumerator CreatObstaclesCoroutine() {
        while (true) {
            yield return new WaitForSeconds(2);

            if (level == null) yield return null;

            int randomObstacle = Random.Range(0, level.GetObstacles().Count);

            GameObject newObstacle = Instantiate(
                level.GetObstacles()[randomObstacle], transform
            );

            newObstacle.transform.localPosition = obstacleSpawnPoint;

        }
    }

    private void StopSpawningObstacles() {
        StopCoroutine(CreatObstacles);
    }
}
