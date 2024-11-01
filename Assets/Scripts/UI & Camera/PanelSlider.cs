using System.Collections;
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
    private bool menuOpened;
    private IEnumerator currentMoveCoroutine;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start() {
        sizeDeltaX = rectTransform.sizeDelta.x;
        finalPos = Mathf.Abs(sizeDeltaX / 2) - offset;
        startingPos = rectTransform.anchoredPosition.x;
    }

    public void StartMoving() {
        if (currentMoveCoroutine != null) {
            return;
        }

        // Toggle main menu buttons
        buttonManager.ToggleCanvasGroup(mainMenu);

        // Check if the menu should be closed or open
        if (!menuOpened) {
            // Check if there is other open menu
            PanelSlider otherMenu = MainMenuManager.instance.GetOpenedMenu();
            if (otherMenu != null) {
                // Hide the other open menu
                buttonManager.ToggleMenu(otherMenu);
            }

            // Set new open menu to the open one
            MainMenuManager.instance.SetOpenedMenu(this);

            // Open the new menu
            currentMoveCoroutine = SlowlyMove(finalPos);
            StartCoroutine(currentMoveCoroutine);
            menuOpened = true;
            return;
        }

        menuOpened = false;

        // Close now open menu
        currentMoveCoroutine = SlowlyMove(startingPos);
        StartCoroutine(currentMoveCoroutine);
        MainMenuManager.instance.SetOpenedMenu(null);
    }

    private IEnumerator SlowlyMove(float destination) {
        timeCount = 0;

        // Loop while the menu to open is not yet at the destination
        while (CanMove(destination)) {
            float t = timeCount * movingSpeed;

            // Calculate slowly way to the destination
            float finalX = Mathf.Lerp(
                rectTransform.anchoredPosition.x,
                destination,
                t
            );

            // Set new position of the menu
            rectTransform.anchoredPosition = new Vector2(
                finalX,
                rectTransform.anchoredPosition.y
            );

            timeCount += Time.deltaTime;
            yield return null;
        }

        // Toggle main menu buttons
        buttonManager.ToggleCanvasGroup(mainMenu);
        currentMoveCoroutine = null;
    }

    private bool CanMove(float destination) {
        float distance = rectTransform.anchoredPosition.x - destination;
        return (Mathf.Abs(distance) > 10);
    }
}
