using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Settings/New Settings")]
public class Settings : ScriptableObject {
    public float BackgroundMusicSlider { get; set; }
    public float SoundEffectSlider { get; set; }
    public bool IsLoaded { get; set; }

    public void OnSettingsOpen() {
        SettingsManager.instance.GetMusicSlider().value = 
            BackgroundMusicSlider;

        SettingsManager.instance.GetSoundEffectsSlider().value = 
            SoundEffectSlider;
        IsLoaded = true;
    }

    public void OnSettingsClose() {
        IsLoaded = false;
    }

}
