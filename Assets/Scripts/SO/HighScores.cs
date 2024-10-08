using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New HighScores Data", menuName = "HighScores/New HighScores Data")]
public class HighScores : ScriptableObject {
    [SerializeField] private HighScore[] scores;

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
