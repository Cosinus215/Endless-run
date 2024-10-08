using System.Collections.Generic;
using UnityEngine;

public enum LevelName { 
    Easy,
    Medium,
    Hard
}

[CreateAssetMenu(fileName = "Level", menuName = "New Level/Level")]
public class Level : ScriptableObject {
    [SerializeField] private List<GameObject> obstacles = new();
    [SerializeField] private LevelName levelName;

    public List<GameObject> GetObstacles() => obstacles; 

    public LevelName GetLevelName() => levelName;
}
