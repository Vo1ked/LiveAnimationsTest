using UnityEngine.Localization.Settings;
using Zenject;
using VolkCore.Game;

namespace LiveAnimationTest
{
    public class ProjectContext : MonoInstaller
    {
        public  override async void InstallBindings()
        {
            Container.Bind<Volume>().AsSingle().NonLazy();

            SignalBusInstaller.Install(Container);
        }
    }
}
