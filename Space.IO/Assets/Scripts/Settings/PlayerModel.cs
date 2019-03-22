using UnityEngine;

namespace Assets.Scripts.Settings
{
    [CreateAssetMenu(fileName = "GameInstaller", menuName = "Installers/PlayerModel")]
    public class PlayerModel : ScriptableObject
    {
        public float MaxHealth;
        public float WalkSpeed;
    }
}
