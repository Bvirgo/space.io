using UnityEngine;
using Zenject;

namespace Assets.Scripts.Settings
{
    [CreateAssetMenu(fileName = "GameInstaller", menuName = "Installers/GameInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public override void InstallBindings()
        {

        }
    }
}