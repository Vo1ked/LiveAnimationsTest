using Save;
using UnityEngine;
using UnityEngine.UI;
using Volk.SceneManagement;
using VolkCharacters.Signals;
using VolkCore.SceneManagement.UI;
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
        [Inject] ISceneManager<Scenes> _sceneManager;
        [Inject] ILoadingScreen _loadingScreen;

        private bool _loadingInProgress = false;
        private async void Awake()
        {
            await _levelProgress;
            if (_levelProgress.MaximumAvailableLevel.Value > 1)
            {
                _continueButton.gameObject.SetActive(true);
                _continueButton.onClick.AddListener(() => LoadDirectLevel(_levelProgress.MaximumAvailableLevel.Value));
            }
            _exitButton.onClick.AddListener(Application.Quit);
            _startGameButton.onClick.AddListener(StartNewGame);
            _signalBus.Subscribe<CharacterSelectedSignal>(()=> LoadDirectLevel(_levelProgress.CurrentLevelId.Value));
            _signalBus.Subscribe<LevelSelectedSignal>(DirectLevelSelected);
        }

        private void DirectLevelSelected(LevelSelectedSignal obj)
        {
            _characterSelectPopup.SetActive(true);
        }

        private void StartNewGame()
        {
            _characterSelectPopup.SetActive(true);
            _levelProgress.SelectLevel(0);
        }
        

        private void LoadDirectLevel(int selectedLevel)
        {
            if (_loadingInProgress)
                return;
            _loadingInProgress = true;
            _levelProgress.SelectLevel(selectedLevel);
            _loadingScreen.FakeLoad();
            _ = _sceneManager.LoadSceneAsync(Scenes.Game1);
        }

        private void OnDestroy()
        {
            _signalBus.TryUnsubscribe<CharacterSelectedSignal>(()=> LoadDirectLevel(1));
        }

    }
}