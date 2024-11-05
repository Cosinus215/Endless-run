using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour { 
    private AudioSource audioSource;
    public static MusicManager instance;
    public float test;
    public float speed;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();

        if (instance != null) {
            Destroy(this);
        }
        instance = this;
    }

    private void Start() {
        StartCoroutine(PingPongStereoPan());
    }

    private IEnumerator PingPongStereoPan() {
        while (true) {
            audioSource.panStereo = Mathf.PingPong(Time.time * speed, 2) - 1;
            yield return null;
        }
    }

    public AudioSource GetAudioSource() {
        return audioSource;
    }
}
