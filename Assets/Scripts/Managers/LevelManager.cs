using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static LevelManager instance;
    private Level chosenLevel;

    public Level GetChosenLevel() {
        return chosenLevel;
    }

    public LevelName GetChosenLevelName() => chosenLevel.GetLevelName();

    public void SetChosenLevel(Level value) {
        chosenLevel = value;
    }

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else { 
            Destroy(instance);
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }


}
