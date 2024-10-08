using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour {
    public static Timer Instance;
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private HighScores highScores;
    private float timer;
    private Coroutine UpdateTimer;

    private void Start() {
        CustomEvent.instance.onPlayerDie += StopTimer;

        if (Instance != null) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }

        UpdateTimer = StartCoroutine(UpdateTimerCoroutin());
    }

    public void StopTimer() {
        StopCoroutine(UpdateTimer);
        SaveHighScore();
    }

    private void SaveHighScore() {
        highScores.SetHighScore(LevelManager.instance.GetChosenLevelName(), pointsText.text);
    }

    private IEnumerator UpdateTimerCoroutin() {
        while (true) {
            timer += Time.deltaTime;
            TimeSpan timeSpan = TimeSpan.FromSeconds(timer);
            pointsText.SetText($"{timeSpan:hh\\:mm\\:ss\\.ff}");
            yield return null;
        }
    }
}

