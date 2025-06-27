using Save;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VolkArkanoid.Signals;
using Zenject;

namespace LiveAnimationTest
{
    public class WinPopup : MonoBehaviour
    {
        [SerializeField] private Button _nextLevel;
        [SerializeField] private Button _main;
        [SerializeField] private GameObject _popup;
        
        [Inject] private ILevelProgress _levelProgress;
        [Inject] private SignalBus _signalBus;

        private void Awake()
        {
            _nextLevel.onClick.AddListener(Nextlevel);
            _main.onClick.AddListener(ToMainMenu);
            _signalBus.Subscribe<GameWinSignal>(ShowPopup);
        }

        private void ShowPopup()
        {
            _popup.SetActive(true);
        }

        private void Nextlevel()
        {
            _levelProgress.CurrentLevelId++;
            
            SceneManager.LoadScene(1);// load scene to reload
        }

        private void ToMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}