using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VolkCharacters;
using VolkCharacters.Save;
using Zenject;
using VolkCore.Game;

namespace LiveAnimationTest
{
    public class ProjectContext : MonoInstaller
    {
       [SerializeField] private PlayerCharactersData _playerCharactersData;
       [SerializeField] private ManualCreatedLevels _manualCreatedLevels;
        
        public override void InstallBindings()
        {
            Container.Bind<ICharactersData<ACharacter>>()
                .FromInstance(_playerCharactersData).AsSingle();
            Container.Bind<PlayerCharactersData>().FromInstance(_playerCharactersData).AsSingle();
            BindCharacterSprites();
            Container.Bind<ALevelFactory<LevelData>>().FromInstance(_manualCreatedLevels).AsSingle();
            Container.BindInterfacesTo<ArkanoidGameLevels>().AsSingle();
            Container.Bind<Volume>().AsSingle().NonLazy();
            SignalBusInstaller.Install(Container);
        }

        private void BindCharacterSprites()
        {
            Dictionary<int, Sprite> sprites = _playerCharactersData.Characters
                .ToDictionary(character=>character.Id, character=>character.CharacterSpriteView.Sprite);
            Container.Bind<Dictionary<int,Sprite>>().FromInstance(sprites).AsSingle();
        }
    }
}
