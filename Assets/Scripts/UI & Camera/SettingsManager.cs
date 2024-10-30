using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {
    public static SettingsManager instance;
    [SerializeField] private Slider backgroundMusicSlider;
    [SerializeField] private Slider soundEffectsSlider;

    private void Awake() {
        if (instance != null) {
            Destroy(this);
        }
        instance = this;
    }


    public Slider GetMusicSlider() {
        return backgroundMusicSlider;
    }
    public Slider GetSoundEffectsSlider() {
        return soundEffectsSlider;
    }
}
