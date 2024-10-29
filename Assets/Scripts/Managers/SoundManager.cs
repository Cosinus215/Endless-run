using UnityEngine;

public class SoundManager : MonoBehaviour {
    private AudioSource audioSource;
    public static SoundManager instance;


    private void Awake() {
        audioSource = GetComponent<AudioSource>();

        if (instance != null) {
            Destroy(this);
        }
        instance = this;
    }

    public AudioSource GetAudioSource() {
        return audioSource;
    }
}
