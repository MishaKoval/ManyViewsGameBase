using System;
using System.Globalization;
using UnityEngine;

namespace Core.Utils
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class PlayerPreferences
    {
        private const string MusicKey = "Music";
        private const string SoundKey = "Sound";
        private const string CollectBonusDateKey = "CollectBonusDate";
        private const string DaysStreakKey = "DaysStreak";
        private const string TodayRewardCollectKey = "TodayRewardCollect";
        
        public bool MusicEnabled => PlayerPrefs.HasKey(MusicKey);
        public bool SoundsEnabled => PlayerPrefs.HasKey(SoundKey);
        public bool IsTodayRewardCollect => PlayerPrefs.HasKey(TodayRewardCollectKey);

        public int DaysStreak
        {
            get
            {
                var days = PlayerPrefs.GetInt(DaysStreakKey, 0);
                return days;
            }
            set => PlayerPrefs.SetInt(DaysStreakKey,value);
        }

        public DateTime CollectBonusDate
        {
            get
            {
                var stringTime = PlayerPrefs.GetString(CollectBonusDateKey, string.Empty);
                if (string.IsNullOrEmpty(stringTime))
                {
                    CollectBonusDate = DateTime.Now.Date;
                    return DateTime.Now.Date;
                }
                
                return DateTime.Parse(stringTime);
            }
            set => PlayerPrefs.SetString(CollectBonusDateKey, value.ToString(CultureInfo.CurrentCulture));
        }

        public void OnChangeTodayCollectState(bool state)
        {
            if (state)
            {
                if (!PlayerPrefs.HasKey(TodayRewardCollectKey))
                {
                    PlayerPrefs.SetInt(TodayRewardCollectKey,1);
                }
            }
            else
            {
                PlayerPrefs.DeleteKey(TodayRewardCollectKey);
            }
            PlayerPrefs.Save();
        }

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