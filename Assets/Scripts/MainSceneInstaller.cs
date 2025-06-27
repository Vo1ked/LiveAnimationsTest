using UnityEngine;
using VolkCharacters;
using VolkCharacters.Signals;
using VolkCore.Game;
using VolkCore.Signals;
using VolkCore.UI;
using Zenject;

namespace LiveAnimationTest
{
    public class MainSceneInstaller : ASceneInstaller
    {
        [SerializeField] private TopPanel _topPanel;

        public override void InstallBindings()
        {
            if (!CheckAndLogDependencies())
                return;
            Container.Bind<IUiLock>().WithId("CharacterSelect")
                .To<MockUiLock>().FromNew().AsSingle();
            Container.Bind<TopPanel>().FromInstance(_topPanel).AsSingle();
            Container.DeclareSignal<CharacterSelectedSignal>();
            Container.DeclareSignal<LevelSelectedSignal>();
        }
    }
}