using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI.Content
{
    [RequireComponent(typeof(Button))]
    public class DailyRewardButton : MonoBehaviour
    {
        [SerializeField] private int dayNumber;
        [SerializeField] private int rewardValue;
        [SerializeField] private TMP_Text dayText;
        [SerializeField] private TMP_Text rewardText;
        [SerializeField] private Color rewardedColor;
        public Button RewardButton { get; private set; }

        private void Awake()
        {
            RewardButton = GetComponent<Button>();
        }

        private void OnEnable()
        {
            dayText.text = "DAY" + " " + dayNumber;
            rewardText.text = "x" + rewardValue;
        }

        public void OnReward()
        {
            SetRewarded();
        }

        public void SetRewarded()
        {
            RewardButton.image.color = rewardedColor;
        }

        public void SetUnreachable()
        {
            RewardButton.interactable = false;
        }
    }
}