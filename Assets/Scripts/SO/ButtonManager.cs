using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "ButtonManager", menuName = "ButtonManager/New ButtonManager")]
public class ButtonManager : ScriptableObject {
    [SerializeField] private Settings settings;

    public void LoadGamePlayScene() {
        PlayButtonClickSound();
        MainMenuManager.instance.StartMovingCanvas();
    } 
    
    public void RestartGamePlayScene() {
        PlayButtonClickSound();
        SceneManager.LoadScene(1);
    }
    
    public void LoadMenuScene() {
        PlayButtonClickSound();
        SceneManager.LoadScene(0);
    }

    public void SetLevel(Level level) {
        PlayButtonClickSound();
        LevelManager.instance.SetChosenLevel(level);
    }

    public void ToggleCanvasGroup(CanvasGroup canvasGroup) {
        canvasGroup.interactable = !canvasGroup.interactable;
    }

    public void SwitchMusic(AudioClip backgroundMusic) {
        MusicManager.instance.PlayMusic(backgroundMusic);
    }
    
    public void SoundSlider(float value) {
        if (settings.IsLoaded == false) return;
    
        SoundManager.instance.GetAudioSource().volume = value;
    
        settings.SetSoundEffectSlider(value);
    }
    
    public void MusicSlider(float value) {
        if (settings.IsLoaded == false) return;
    
        MusicManager.instance.GetAudioSource().volume = value;
    
        settings.SetBackgroundMusicSlider(value);
    }

    public void ChangeGraphicsSetting(int graphicsLevel) {
        PlayButtonClickSound();
        QualitySettings.SetQualityLevel(graphicsLevel, true);

        settings.SelectedGraphics = graphicsLevel;
    }
    
    private void PlayButtonClickSound() {
        SoundManager.instance.PlaySound();
    }

    public void ToggleGameObject(GameObject objectToActivate) {
        PlayButtonClickSound();
        objectToActivate.SetActive(!objectToActivate.activeSelf);
    }

    public void ToggleMenu(PanelSlider menu) {
        PlayButtonClickSound();
        menu.StartMoving();
    }

    public void ExitGame() {
        Application.Quit();

        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #endif
    }

}
