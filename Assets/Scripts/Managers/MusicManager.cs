using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour { 
    private AudioSource audioSource;
    public static MusicManager instance;
    public float test;
    public float speed;

    void Awake() {
        DontDestroyOnLoad(gameObject);

        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        StartCoroutine(PingPongStereoPan());
    }

    public AudioSource GetAudioSource() {
        return audioSource;
    }

    public void PlayMusic(AudioClip clip) {
        audioSource.clip = clip;
        audioSource.Play();
    }

    private IEnumerator PingPongStereoPan() {
        while (true) {
            audioSource.panStereo = Mathf.PingPong(Time.time * speed, 2) - 1;
            yield return null;
        }
    }
}
