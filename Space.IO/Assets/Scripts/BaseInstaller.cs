using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class BaseInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<string>().FromInstance("Hello World!");
            Container.Bind<Greeter>().AsSingle().NonLazy();
        }
    }
}