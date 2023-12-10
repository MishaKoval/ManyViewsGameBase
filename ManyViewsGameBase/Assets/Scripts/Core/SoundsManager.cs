using UnityEngine;

namespace Core
{
    public class SoundsManager : MonoBehaviour
    {
        [SerializeField] private AudioSource backgroundMusicSource;
        [SerializeField] private AudioSource buttonClickSoundSource;

        private bool isSoundEnabled;

        public void Init(bool music,bool sound)
        {
            isSoundEnabled = sound;
            if (music)
            {
                PlayBackgroundMusic();
            }
            else
            {
                StopBackgroundMusic();
            }
        }

        public void PlayButtonClickSound()
        {
            if (isSoundEnabled)
            {
                buttonClickSoundSource.Play();
            }
        }

        public void SetSoundState(bool state)
        {
            isSoundEnabled = state;
        }

        public void PlayBackgroundMusic()
        {
            backgroundMusicSource.Play();
        }
        
        public void StopBackgroundMusic()
        {
            backgroundMusicSource.Stop();
        }
    }
}