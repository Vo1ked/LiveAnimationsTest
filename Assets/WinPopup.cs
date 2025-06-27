using Save;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VolkCore.Save;
using Zenject;

namespace LiveAnimationTest
{
    public class WinPopup : MonoBehaviour
    {
        [SerializeField] private Button _repeat;
        [SerializeField] private Button _main;
        
        [Inject] private ILevelProgress _levelProgress;

        private void Awake()
        {
            _repeat.onClick.AddListener(Nextlevel);
            _main.onClick.AddListener(ToMainMenu);
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