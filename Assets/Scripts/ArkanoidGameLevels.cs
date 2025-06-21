using VolkCore.Save;

namespace LiveAnimationTest
{
    public class ArkanoidGameLevels : AGameLevels<LevelData>
    { 
        protected override string GameName => "ArkanoidGameLevels";

        protected override void LoadLevels()
        {
            Levels = _levelFactory.GenerateLevels();
        }
    }
}