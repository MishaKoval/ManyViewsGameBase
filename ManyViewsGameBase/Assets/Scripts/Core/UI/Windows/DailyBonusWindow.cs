using System.Collections.Generic;
using Core.UI.Content;
using Core.UI.Intents;
using Core.UI.Windows.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI.Windows
{
    public class DailyBonusWindow : SecondaryWindow<DailyBonusIntent>
    {
        [SerializeField] private GameObject day1_6Content;
        [SerializeField] private GameObject day7Content;
        [SerializeField] private List<DailyRewardButton> dailyRewards;
        [SerializeField] private Slider dailyProgressSlider;
        
        protected override void OnOpened()
        {
            base.OnOpened();
            Init();
            SetupButtonsClick();
        }

        protected override void OnClosed()
        {
            base.OnClosed();
            UnsubscribeButtons();
        }

        private void Init()
        {
            if (Intent.DaysStreak.CurrentDaysStreak > 6)
            {
                EnableDay7Content();
            }
            else
            {
                EnableDay1_6Content();
            }
            SetSliderValue();
            SetRewardButtons();
        }

        private void SetupButtonsClick()
        {
            for (int i = 0; i < dailyRewards.Count; i++)
            {
                int index = i;
                dailyRewards[i].RewardButton.onClick.AddListener(() =>
                {
                    dailyRewards[index].SetRewarded();
                });
            }
            //todo vallet
        }

        private void UnsubscribeButtons()
        { 
            for (int i = 0; i < dailyRewards.Count; i++)
            {
                dailyRewards[i].RewardButton.onClick.RemoveAllListeners();
            }
        }

        private void EnableDay7Content()
        {
            day7Content.SetActive(true);
        }
        
        private void EnableDay1_6Content()
        {
            day1_6Content.SetActive(true);
        }

        private void SetSliderValue()
        {
            dailyProgressSlider.value = Intent.DaysStreak.CurrentDaysStreak / 7.0f;
        }

        private void SetRewardButtons()
        {
            int daysStreak = Intent.DaysStreak.CurrentDaysStreak;
            for (int i = 0; i < dailyRewards.Count; i++)
            {
                if (i < daysStreak)
                {
                    dailyRewards[i].SetRewarded();
                }

                if (i == daysStreak && Intent.DaysStreak.IsTodayRewardCollect)
                {
                    dailyRewards[i].SetRewarded();
                }

                if (i> daysStreak)
                {
                    dailyRewards[i].SetUnreachable();
                }
            }
        }
    }
}