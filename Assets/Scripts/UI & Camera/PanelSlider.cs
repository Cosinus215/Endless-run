using System.Collections;
using UnityEditor;
using UnityEngine;

public class PanelSlider : MonoBehaviour {
    [SerializeField] private float offset = 200;
    [SerializeField] private CanvasGroup mainMenu;
    [SerializeField] private ButtonManager buttonManager;
    [SerializeField] private float movingSpeed = 0.05f;
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
            PanelSlider otherMenu = MainMenuManager.instance.GetOpenedMenu();
            if (otherMenu != null) {
                buttonManager.ToggleMenu(otherMenu);
            }
            MainMenuManager.instance.SetOpenedMenu(this);
            StartCoroutine(SlowlyMove(finalPos)); 
            i++;
            return; 
        }

        i = 0; 
        StartCoroutine(SlowlyMove(startingPos)); 
        MainMenuManager.instance.SetOpenedMenu(null);
    }

    private IEnumerator SlowlyMove(float destination) {
        buttonManager.ToggleCanvasGroup(mainMenu);
        timeCount = 0;
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
        buttonManager.ToggleCanvasGroup(mainMenu);
    }

    private bool CanMove(float destination) {
        float distance = rectTransform.anchoredPosition.x - destination;
        return (Mathf.Abs(distance) > 10);
    }
}
