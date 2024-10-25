using System.Collections;
using UnityEditor;
using UnityEngine;

public class LevelMenu : MonoBehaviour {
    [SerializeField] private float offset;
    [SerializeField] private float movingSpeed;
    private RectTransform rectTransform;
    private float startingPos;
    private float sizeDeltaX;
    private float finalPos;
    private float timeCount;
    private int i = 0;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        
    }

    private void Start() {
        sizeDeltaX = rectTransform.sizeDelta.x;
        finalPos = Mathf.Abs(sizeDeltaX / 2) - offset;
        startingPos = rectTransform.anchoredPosition.x;
    }

    public void StartMoving() {
        if (i == 0) {
            StartCoroutine(SlowlyMove(finalPos));
            i++;
            return;
        }
        i = 0;

        StartCoroutine(SlowlyMove(startingPos));
    }

    private IEnumerator SlowlyMove(float destination) {
        while (CanMove(destination)) {
            float t = timeCount * movingSpeed;
            float finalX = Mathf.Lerp(
                rectTransform.anchoredPosition.x,
                destination,
                t
            );
            
            rectTransform.anchoredPosition = new Vector2(
                finalX, 
                rectTransform.anchoredPosition.y
            );
            timeCount += Time.deltaTime;
            yield return null;
        }
    }

    private bool CanMove(float destination) {
        float distance = rectTransform.anchoredPosition.x - destination;
        return (Mathf.Abs(distance) > 10);
    }
}
