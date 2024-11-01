using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    public static MainMenuManager instance;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject canvaToMove;
    [SerializeField] private HighScores highScores;
    [SerializeField] private TextMeshProUGUI highScoreEasyText;
    [SerializeField] private TextMeshProUGUI highScoreMediumText;
    [SerializeField] private TextMeshProUGUI highScoreHardText;
    private AsyncOperation sceneLoaded;
    private Camera mainCamera;
    private BackgroundColor backgroundColor;
    private AudioListener audioListener;
    private float cameraHorizontalBorder;
    private PanelSlider openedMenu;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        GetDefaultVariables();
        LoadGameplayScene();
        SetHighScores();
    }
    
    private void SetHighScores() {
        foreach (HighScore score in highScores.GetHighScores()) {

            switch (score.levelName) {
                case LevelName.Easy:
                    highScoreEasyText.SetText($"{score.levelName}: {score.time}");
                    break;
                case LevelName.Medium:
                    highScoreMediumText.SetText($"{score.levelName}: {score.time}");
                    break;
                case LevelName.Hard:
                    highScoreHardText.SetText($"{score.levelName}: {score.time}");
                    break;
        
            }
        }
    }

    private void GetDefaultVariables() {
        mainCamera = Camera.main;
        backgroundColor = mainCamera.GetComponent<BackgroundColor>();
        audioListener = mainCamera.GetComponent<AudioListener>();
        cameraHorizontalBorder =
            Helpers.CameraHelper.GetCameraBordersWorldPosition().x / 2;
    }

    private void LoadGameplayScene() {
        sceneLoaded = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        sceneLoaded.allowSceneActivation = false;
    }

    public void StartMovingCanvas() {
        StartCoroutine(MoveCanvas());
    }

    private IEnumerator MoveCanvas() {
        sceneLoaded.allowSceneActivation = true;

        while (sceneLoaded.isDone) {
            yield return null;
        }

        OnStartAnimation();
        yield return new WaitForSeconds(1);
    
        while (true) { 
            // Check if Menu buttons are outside the camera view
            if (canvaToMove.transform.position.x < -cameraHorizontalBorder)
                OutsideOfCamera();

            canvaToMove.transform.position -= new Vector3(0.04f, 0, 0);
            yield return null;

        }
    }

    private void OutsideOfCamera() {
        mainCamera.depth = 0;
        SceneManager.UnloadSceneAsync(0);
    }

    private void OnStartAnimation() {
        player.SetActive(false);
        backgroundColor.enabled = true;
        audioListener.enabled = false;
        EventSystem.current.enabled = false;
    }

    public void SetOpenedMenu(PanelSlider menu) {
        openedMenu = menu;
    } 
    
    public PanelSlider GetOpenedMenu() {
        return openedMenu;
    }
}
