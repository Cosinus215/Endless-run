using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLevel : MonoBehaviour {
    [SerializeField] private List<GameObject> obstacles = new();
    private Coroutine CreatObstacles;
    private Vector2 obstacleSpawnPoint;

    private void Start() {
        SetObstaclesSpawnPoint();
        CustomEvent.instance.onPlayerDie += StopSpawningObstacles;

        CreatObstacles = StartCoroutine(CreatObstaclesCoroutine());
    }

    private void SetObstaclesSpawnPoint() {
        Vector2 screenBorders = 
            Helpers.CameraHelper.GetCameraBordersWorldPosition();
        obstacleSpawnPoint = new Vector2(screenBorders.x + 3, 0);
    }

    private IEnumerator CreatObstaclesCoroutine() {
        while (true) {
            int randomObstacle = Random.Range(0, obstacles.Count);

            GameObject newObstacle = Instantiate(
                obstacles[randomObstacle], transform
            );

            newObstacle.transform.localPosition = obstacleSpawnPoint;

            yield return new WaitForSeconds(2);
        }
    }

    private void StopSpawningObstacles() {
        StopCoroutine(CreatObstacles);
    }
}
