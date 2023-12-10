using System;

namespace Core.Utils
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class DaysStreak
    {
        private readonly PlayerPreferences playerPreferences;
        public int CurrentDaysStreak { get; }
        public bool IsTodayRewardCollect { get; }

        public DaysStreak(PlayerPreferences playerPreferences)
        {
            this.playerPreferences = playerPreferences;
            CurrentDaysStreak = this.playerPreferences.DaysStreak;
            IsTodayRewardCollect = this.playerPreferences.IsTodayRewardCollect;
            var lastCollectBonusDate = this.playerPreferences.CollectBonusDate;
            if ((DateTime.Now - lastCollectBonusDate).Hours > 48)
            {
                CurrentDaysStreak = 0;
                this.playerPreferences.DaysStreak = CurrentDaysStreak;
            }

            if ((DateTime.Now - lastCollectBonusDate).Hours > 24)
            {
                CurrentDaysStreak++;
                this.playerPreferences.DaysStreak = CurrentDaysStreak;
            }
        }

        public void OnCollectDailyReward()
        {
            playerPreferences.CollectBonusDate = DateTime.Now;
            playerPreferences.OnChangeTodayCollectState(true);
        }
    }
}