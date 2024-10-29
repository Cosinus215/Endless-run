using UnityEngine;

public class MusicManager : MonoBehaviour { 
    private AudioSource audioSource;
    public static MusicManager instance;

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
