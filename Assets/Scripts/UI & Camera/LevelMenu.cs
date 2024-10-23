using System.Collections;
using UnityEngine;

public class LevelMenu : MonoBehaviour {
    [SerializeField] private float offset;
    [SerializeField] private float movingSpeed;
    private RectTransform rectTransform;
    private float sizeDeltaX;
    private float finalPos;
    private float timeCount;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        sizeDeltaX = rectTransform.sizeDelta.x;
        finalPos = Mathf.Abs(sizeDeltaX / 2) - offset;
    }

    private void Start() {
        StartCoroutine(SlowlyMove());
    }

    private IEnumerator SlowlyMove() {
        while (rectTransform.anchoredPosition.x > finalPos) {
            float t = timeCount * movingSpeed;
            float finalX = Mathf.Lerp(
                rectTransform.anchoredPosition.x, 
                finalPos,
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
}
