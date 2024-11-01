using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {
    public static SettingsManager instance;
    [SerializeField] private Settings settings;
    [SerializeField] private Slider backgroundMusicSlider;
    [SerializeField] private Slider soundEffectsSlider;
    [SerializeField] private Button lowGraphicsButton;
    [SerializeField] private Button mediumGraphicsButton;
    [SerializeField] private Button highGraphicsButton;
    private readonly List<Button> graphicSetting = new();

    private void Awake() {
        if (instance != null) {
            Destroy(this);
        }
        instance = this;
    }

    private void Start() {
        AddGraphicSettingToList();
    }

    private void AddGraphicSettingToList() {
        graphicSetting.Add(lowGraphicsButton);
        graphicSetting.Add(mediumGraphicsButton);
        graphicSetting.Add(highGraphicsButton);
    }

    public Slider GetMusicSlider() {
        return backgroundMusicSlider;
    }

    public Slider GetSoundEffectsSlider() {
        return soundEffectsSlider;
    }

    public void SetGrapgicSetting(int value) {
        graphicSetting[value].Select();
    }
}
