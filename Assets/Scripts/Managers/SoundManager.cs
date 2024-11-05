using UnityEngine;

public class SoundManager : MonoBehaviour {
    private AudioSource audioSource;
    public static SoundManager instance;

    void Awake() {
        DontDestroyOnLoad(gameObject);

        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }


    public AudioSource GetAudioSource() {
        return audioSource;
    }

    public void PlaySound() {
        audioSource.Play();
    }
}
