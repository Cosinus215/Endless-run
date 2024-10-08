using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New HighScores Data", menuName = "HighScores/New HighScores Data")]
public class HighScores : ScriptableObject {
    [SerializeField] private HighScore[] scores;

    private void OnValidate() {
        foreach (HighScore score in scores) { 
            if (score.time.Length == 0) score.time = "00:00:00.00";
        }
    }

    public void SetHighScore(LevelName level, string newHighScore) {

        foreach (HighScore score in scores) {
            if (score.levelName == level) {
                score.time = newHighScore;
            }
        }
    }

    public HighScore[] GetHighScores() => scores;
}

[Serializable]
public class HighScore {
    public LevelName levelName;
    public string time;
}
