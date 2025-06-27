using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VolkArkanoid.Signals;
using Zenject;

namespace LiveAnimationTest
{
    public class LosePopup : MonoBehaviour
    {
        [SerializeField] private Button _repeat;
        [SerializeField] private Button _main;
        [SerializeField] private GameObject _popup;

        [Inject] private SignalBus _signalBus;

        private void Awake()
        {
            _repeat.onClick.AddListener(Reply);
            _main.onClick.AddListener(ToMainMenu);
            _signalBus.Subscribe<GameLoseSignal>(ShowPopup);
        }
        
        private void ShowPopup()
        {
            _popup.SetActive(true);
        }

        private void Reply()
        {
            SceneManager.LoadScene(1);// load scene to reload
        }

        private void ToMainMenu()
        {
            SceneManager.LoadScene(0);
        }

    }
}
