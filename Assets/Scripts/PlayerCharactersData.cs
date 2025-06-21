using UnityEngine;
using VolkCharacters.Save;

namespace LiveAnimationTest
{
    [CreateAssetMenu(fileName = "Characters", menuName = "Volk/Characters Data", order = 1)]
    public class PlayerCharactersData : ACharactersData<PlayerArkanoidCharacterWithHeals> { }
}