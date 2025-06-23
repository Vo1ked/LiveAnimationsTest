using Save;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VolkCharacters.Signals;
using VolkCore.Signals;
using Zenject;

namespace LiveAnimationTest
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private GameObject _characterSelectPopup;

        [Inject] ILevelProgress _levelProgress;
        [Inject] SignalBus _signalBus;
        private void Awake()
        {
            if (_levelProgress.MaxOppenedLevel > 1)
            {
                _continueButton.gameObject.SetActive(true);
                _continueButton.onClick.AddListener(() => LoadDirectLevel(_levelProgress.MaxOppenedLevel));
            }
            _exitButton.onClick.AddListener(Application.Quit);
            _startGameButton.onClick.AddListener(StartNewGame);
            _signalBus.Subscribe<CharacterSelectedSignal>(()=> LoadDirectLevel(_levelProgress.CurrentLevelId));
            _signalBus.Subscribe<LevelSelectedSignal>(DirectLevelSelected);
        }

        private void DirectLevelSelected(LevelSelectedSignal obj)
        {
            _characterSelectPopup.SetActive(true);
        }

        private void StartNewGame()
        {
            _characterSelectPopup.SetActive(true);
            _levelProgress.CurrentLevelId = 0;
        }
        

        private async void LoadDirectLevel(int selectedLevel)
        {
            _levelProgress.CurrentLevelId = selectedLevel;
            await SceneManager.LoadSceneAsync("Game",LoadSceneMode.Additive);
            await SceneManager.UnloadSceneAsync("MainMenu");
        }

        private void OnDestroy()
        {
            _signalBus.TryUnsubscribe<CharacterSelectedSignal>(()=> LoadDirectLevel(1));
        }

    }
}