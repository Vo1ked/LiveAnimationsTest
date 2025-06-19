using Zenject;
using VolkCore.Save;
using VolkCore.Game;

namespace LiveAnimationTest
{
    public class ProjectContext : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Volume>().AsSingle().NonLazy();
            SignalBusInstaller.Install(Container);
        }
    }
}
