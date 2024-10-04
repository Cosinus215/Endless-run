using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "New Level/Level")]
public class Level : ScriptableObject {
    [SerializeField] private List<GameObject> obstacles = new();

    public List<GameObject> GetObstacles() {
        return obstacles; 
    }
}
