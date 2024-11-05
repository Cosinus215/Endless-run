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

    void Awake() {
        DontDestroyOnLoad(gameObject);

        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }


}
