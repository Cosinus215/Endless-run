using UnityEngine;

namespace Helpers {
    public class CameraHelper {

        public static Vector2 GetCameraBordersWorldPosition() {
            float worldDistanceFromCamera = -Camera.main.transform.position.z;
            Vector3 bordersScreenPosition = new Vector3(Screen.width, Screen.height, worldDistanceFromCamera);
            Vector2 bordersWorldPosition = Camera.main.ScreenToWorldPoint(bordersScreenPosition);
            return new Vector2(bordersWorldPosition.x, 0);
        }
        
        public static Vector2 GetCameraBorders() {
            float worldDistanceFromCamera = -Camera.main.transform.position.z;
            Vector3 bordersScreenPosition = new Vector3(Screen.width, Screen.height, worldDistanceFromCamera);
            return new Vector2(bordersScreenPosition.x, 0);
        }
    }
}
