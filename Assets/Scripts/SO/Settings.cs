using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Settings/New Settings")]
public class Settings : ScriptableObject {
    [Range(0, 1)][SerializeField] private float backgroundMusicSlider;
    [Range(0, 1)][SerializeField] private float soundEffectSlider;

    public int SelectedGraphics { private get; set; }
    public bool IsLoaded { get; set; }

    public void OnSettingsOpen() {
        SettingsManager settings = SettingsManager.instance;

        settings.GetMusicSlider().value = backgroundMusicSlider;
        settings.GetSoundEffectsSlider().value = soundEffectSlider;

        settings.SetGrapgicSetting(SelectedGraphics);
        IsLoaded = true;
    }

    public void OnSettingsClose() {
        IsLoaded = false;
    }

    public void SetBackgroundMusicSlider(float value) {
        backgroundMusicSlider = value;
    }

    public void SetSoundEffectSlider(float value) {
        soundEffectSlider = value;
    }
}
