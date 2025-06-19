using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using TMPro;
using VolkCore.UI;

namespace LiveAnimationTest
{
    public class LanguageSelector : BasePopUp
    {
        [SerializeField] private Transform buttonsParent;
        [SerializeField] private Button buttonPrefab;

        private void Awake()
        {
            for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; ++i)
            {
                var locale = LocalizationSettings.AvailableLocales.Locales[i];
                
                var currentLanguage = Instantiate(buttonPrefab, buttonsParent);
                currentLanguage.name = locale.name;
                currentLanguage.GetComponentInChildren<TMP_Text>().text = locale.name;
                int i1 = i;
                currentLanguage.onClick.AddListener(()=> LocaleSelected(i1));
            }
            
        }

        private async void LocaleSelected(int index)
        {
            await LocalizationSettings.InitializationOperation.Task;
   
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
        }
    }
}
