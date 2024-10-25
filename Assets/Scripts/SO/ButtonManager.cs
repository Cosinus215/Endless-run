using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "ButtonManager", menuName = "ButtonManager/New ButtonManager")]
public class ButtonManager : ScriptableObject {

    public void LoadGamePlayScene() {
        MainMenuManager.instance.StartMovingCanvas();
    } 
    
    public void RestartGamePlayScene() {
        SceneManager.LoadScene(1);
    }
    
    public void LoadMenuScene() {
        SceneManager.LoadScene(0);
    }

    public void SetLevel(Level level) {
        LevelManager.instance.SetChosenLevel(level);
    }

    public void ToggleCanvasGroup(CanvasGroup canvasGroup) {
        canvasGroup.interactable = false;
    }

    //public void SwitchMusic(AudioClip backgroundMusic) {
    //    MusicManager.instance.PlayMusic(backgroundMusic);
    //}
    //
    //public void GameWon() {
    //    LevelManager.instance.GetLevelTemplate().SetIsWon(true);
    //}
    //
    //public void SoundSlider(float value) {
    //    if (settings.IsLoaded == false) return;
    //
    //    SoundManager.instance.GetAudioSource().volume = value;
    //
    //    settings.SoundEffectSlider = value;
    //}
    //
    //public void MusicSlider(float value) {
    //    if (settings.IsLoaded == false) return;
    //
    //    MusicManager.instance.GetAudioSource().volume = value;
    //
    //    settings.BackgroundMusicSlider = value;
    //}
    //
    //public void ToggleMusic() {
    //    if (settings.IsLoaded == false) return;
    //
    //    bool audioSourceMuted = 
    //        MusicManager.instance.GetAudioSource().mute;
    //
    //    MusicManager.instance.GetAudioSource().mute = !audioSourceMuted;
    //
    //    settings.IsBackgroundMusicOn = audioSourceMuted;
    //}
    //
    //public void ToggleSoundEffects() {
    //    if (settings.IsLoaded == false) return;
    //
    //    bool audioSourceMuted =
    //       SoundManager.instance.GetAudioSource().mute;
    //
    //    SoundManager.instance.GetAudioSource().mute = !audioSourceMuted;
    //
    //    settings.IsSoundEffectOn = audioSourceMuted;
    //}
    //
    //public void ChangeGraphicsSetting(int graphicsLevel) {
    //    if (settings.IsLoaded == false) return;
    //
    //    graphicsLevel = Mathf.Clamp(graphicsLevel, 0, QualitySettings.names.Length - 1);
    //    QualitySettings.SetQualityLevel(graphicsLevel, true);
    //
    //    settings.GraphicsLevel = graphicsLevel;
    //}
    //
    //private void PlayButtonClickSound() {
    //    if (clickSound == null) return;
    //
    //    SoundManager.instance.PlaySound(clickSound);
    //}

    public void ToggleGameObject(GameObject objectToActivate) {
        //PlayButtonClickSound();
        objectToActivate.SetActive(!objectToActivate.activeSelf);
    }

    public void ToggleMenu(LevelMenu menu) {
        
        menu.StartMoving();

    }

    public void TogglePauseGame(CanvasGroup canvasGroup) {
        Time.timeScale = (Time.timeScale == 1f) ? 0.0f : 1.0f;
        canvasGroup.interactable = !canvasGroup.interactable;
    }

    public void ExitGame() {
        Application.Quit();

        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #endif
    }

}
