using UnityEngine;
using VolkCore.Game;

namespace LiveAnimationTest
{
    [CreateAssetMenu(fileName = "Levels", menuName = "Volk/Levels", order = 1)]
    public class ManualCreatedLevels : ALevelFactory<LevelData>
    {
        [field:SerializeField] private LevelData[] _levels;
        public override LevelData[] GenerateLevels()
        {
            return _levels;
        }
    }
}