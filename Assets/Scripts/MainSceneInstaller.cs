using UnityEngine;
using VolkCore.Game;
using VolkCore.UI;

namespace LiveAnimationTest
{
    public class MainSceneInstaller : ASceneInstaller
    {
        [SerializeField] private TopPanel _topPanel;

        public override void InstallBindings()
        {
            if (!CheckAndLogDependencies())
                return;
            
            Container.Bind<TopPanel>().FromInstance(_topPanel).AsSingle();

        }
    }
}