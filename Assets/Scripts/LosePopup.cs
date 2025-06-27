using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LiveAnimationTest
{
    public class LosePopup : MonoBehaviour
    {
        [SerializeField] private Button _repeat;
        [SerializeField] private Button _main;

        private void Awake()
        {
            _repeat.onClick.AddListener(Reply);
            _main.onClick.AddListener(ToMainMenu);
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
