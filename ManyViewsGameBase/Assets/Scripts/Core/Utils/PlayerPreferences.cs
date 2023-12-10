using UnityEngine;

namespace Core.Utils
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class PlayerPreferences
    {
        private const string MusicKey = "Music";
        private const string SoundKey = "Sound";
        
        public bool MusicEnabled => PlayerPrefs.HasKey(MusicKey);
        public bool SoundsEnabled => PlayerPrefs.HasKey(SoundKey);

        public void OnChangeMusicState(bool state)
        {
            if (state)
            {
                if (!PlayerPrefs.HasKey(MusicKey))
                {
                    PlayerPrefs.SetInt(MusicKey,1);
                }
            }
            else
            {
                PlayerPrefs.DeleteKey(MusicKey);
            }
            PlayerPrefs.Save();
        }

        public void OnChangeSoundState(bool state)
        {
            if (state)
            {
                if (!PlayerPrefs.HasKey(SoundKey))
                {
                    PlayerPrefs.SetInt(SoundKey,1);
                }
            }
            else
            {
                PlayerPrefs.DeleteKey(SoundKey);
            }
            PlayerPrefs.Save();
        }
    }
}