using Save;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VolkCore.Game.Level;
using Zenject;

namespace LiveAnimationTest
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _exitButton;

        [Inject] IUserLevel _userLevel;
        [Inject] ILevelProgress _levelProgress;

        private void Awake()
        {
            if (_levelProgress.MaxOppenedLevel > 1)
            {
                _continueButton.gameObject.SetActive(true);
                _continueButton.onClick.AddListener(() => LoadDirectLevel(_levelProgress.MaxOppenedLevel));
            }
            _exitButton.onClick.AddListener(Application.Quit);
            _startGameButton.onClick.AddListener(()=> LoadDirectLevel(1));
        }

        private async void LoadDirectLevel(int selectedLevel)
        {
            _levelProgress.CurrentLevelId = selectedLevel;
            await SceneManager.LoadSceneAsync("Game",LoadSceneMode.Additive);
            await SceneManager.UnloadSceneAsync("MainMenu");
        }

    }
}