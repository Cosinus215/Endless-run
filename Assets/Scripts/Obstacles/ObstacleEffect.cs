using UnityEngine;

[CreateAssetMenu(fileName = "GenericEffect", menuName = "ObstacleEffects/GenericEffect")]
public class ObstacleEffect : ScriptableObject {
    public enum EffectType {
        SuperJump,
        Blindness
    }

    public EffectType effectType;  
    public float intensity;       
    public float duration;        

    public void ApplyEffect(GameObject player) {
        switch (effectType) {
            case EffectType.SuperJump:
                ApplySuperJump(player);
                break;
            case EffectType.Blindness:
                ApplyBlindness();
                break;
        }
        
    }

    private void ApplySuperJump(GameObject player) {
        if (player.TryGetComponent(out Rigidbody2D rb))
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * intensity, ForceMode2D.Impulse);
    }
    
    private void ApplyBlindness() {
        
    }
}
