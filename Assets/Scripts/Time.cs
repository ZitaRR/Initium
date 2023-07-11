using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Initium
{
    public class Time : MonoBehaviour
    {
        public static DateTime startDate = new(1, 1, 1, 12, 0, 0);

        public static Action<string> OnDayPassed;
        public static Action<int> OnYearPassed;

        public DateTime DateTime 
        {
            get => dateTime;
            set
            {
                dateTime = value;
                daysDisplay.text = $"Day {dateTime.FormatDay()}";
                dayDisplay.text = DateTime.DayOfWeek.ToString();
                timeDisplay.text = dateTime.FormatTime(twelveHourClock);
            }
        }

        [SerializeField]
        private TextMeshProUGUI daysDisplay;
        [SerializeField]
        private TextMeshProUGUI dayDisplay;
        [SerializeField]
        private TextMeshProUGUI timeDisplay;
        [SerializeField]
        private Button pauseButton;
        [SerializeField]
        private Button slowButton;
        [SerializeField]
        private Button normalButton;
        [SerializeField]
        private Button fastButton;
        [SerializeField]
        private bool twelveHourClock;

        private DateTime dateTime;
        private GamePace pace = GamePace.Normal;

        private void Awake()
        {
            pauseButton.onClick.AddListener(Pause);
            slowButton.onClick.AddListener(() => Play());
            normalButton.onClick.AddListener(() => Play(GamePace.Fast));
            fastButton.onClick.AddListener(() => Play(GamePace.IAmSpeed));
        }

        private void Start()
        {
            dateTime = startDate;
        }

        private void FixedUpdate()
        {
            if (pace == GamePace.Pause)
            {
                return;
            }

            DateTime previous = DateTime;
            DateTime = DateTime.AddSeconds((int)pace);

            TryAdvanceNewDay(previous);
            TryAdvanceNewYear(previous);
        }

        private void TryAdvanceNewDay(DateTime previous)
        {
            if (DateTime.Day <= previous.Day)
            {
                return;
            }

            OnDayPassed?.Invoke(DateTime.DayOfWeek.ToString());
        }
        
        private void TryAdvanceNewYear(DateTime previous)
        {
            if (DateTime.Year <= previous.Year)
            {
                return;
            }

            OnYearPassed?.Invoke(DateTime.Year);
        }

        public void Pause()
        {
            pace = GamePace.Pause;
        }

        public void Play(GamePace pace = GamePace.Normal)
        {
            this.pace = pace;
        }
    }
}
