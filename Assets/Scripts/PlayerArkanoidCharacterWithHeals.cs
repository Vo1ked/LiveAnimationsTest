using UnityEngine;
using VolkCharacters;

namespace LiveAnimationTest
{
    [CreateAssetMenu(fileName = "Character", menuName = "Volk/Player Arkanoid Character With Heals", order = 1)]
    public class PlayerArkanoidCharacterWithHeals : CharacterWithHeals
    {
        [field:SerializeField] public CharacterSpriteView CharacterSpriteView { get;private set; }
        [field:SerializeField] public Color PlatformColor { get;private set; }
    }
}