using UnityEngine;
using UnityEngine.UI;

namespace Core.UI.Windows
{
    public class SettingsWindow : SecondaryWindow<SettingsWindowIntent>
    {
        [SerializeField] private Toggle soundToggle;
        [SerializeField] private Toggle musicToggle;
        
        protected override void OnOpening()
        {
            base.OnOpening();
            soundToggle.onValueChanged.AddListener(OnSoundToggleChange);
            musicToggle.onValueChanged.AddListener(OnMusicToggleChange);
            soundToggle.isOn = Intent.PlayerPreferences.SoundsEnabled;
            musicToggle.isOn = Intent.PlayerPreferences.MusicEnabled;
        }

        protected override void OnClosing()
        {
            base.OnClosing();
            soundToggle.onValueChanged.RemoveListener(OnSoundToggleChange);
            musicToggle.onValueChanged.RemoveListener(OnMusicToggleChange);
        }

        private void OnSoundToggleChange(bool value)
        {
            Intent.SoundsManager.SetSoundState(value);
            Intent.PlayerPreferences.OnChangeSoundState(value);
        }

        private void OnMusicToggleChange(bool value)
        {
            if (value)
            {
                Intent.SoundsManager.PlayBackgroundMusic();
            }
            else
            {
                Intent.SoundsManager.StopBackgroundMusic();
            }
            Intent.PlayerPreferences.OnChangeMusicState(value);
        }
    }

    public class SettingsWindowIntent : SecondaryWindowsIntent
    {
        public PlayerPreferences PlayerPreferences { get; }

        public SettingsWindowIntent(TransitionAnimation transitionAnimation,SoundsManager soundsManager,PlayerPreferences playerPreferences,EmptyIntent emptyIntent) : base(transitionAnimation,soundsManager,emptyIntent)
        {
            PlayerPreferences = playerPreferences;
        }
    }
}