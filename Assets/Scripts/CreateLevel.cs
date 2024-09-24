using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLevel : MonoBehaviour {
    [SerializeField] private List<GameObject> obstacles = new();
    private Coroutine CreatObstacles;

    private void Start() {
        CustomEvent.instance.onPlayerDie += StopSpawningObstacles;

        CreatObstacles = StartCoroutine(CreatObstaclesCoroutine());
    }

    private IEnumerator CreatObstaclesCoroutine() {
        while (true) {
            int randomObstacle = Random.Range(0, obstacles.Count);

            GameObject newObstacle = Instantiate(
                obstacles[randomObstacle], transform
            );

            newObstacle.transform.localPosition = new Vector2 (0, newObstacle.transform.position.y);

            yield return new WaitForSeconds(2);
        }
    }

    private void StopSpawningObstacles() {
        StopCoroutine(CreatObstacles);
    }
}
