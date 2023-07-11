using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Initium
{
    public class Time : MonoBehaviour
    {
        public static Action<string> OnDayPassed;
        public static Action<int> OnYearPassed;

        public DateTime DateTime 
        {
            get => dateTime;
            set
            {
                dateTime = value;
                dateDisplay.text = dateTime.FormatDate(format);
                timeDisplay.text = dateTime.FormatTime(format);
            }
        }

        [SerializeField]
        private TextMeshProUGUI dateDisplay;
        [SerializeField]
        private TextMeshProUGUI timeDisplay;
        [SerializeField]
        private Button pauseButton;
        [SerializeField]
        private Button normalButton;
        [SerializeField]
        private Button fastButton;

        private DateTime dateTime;
        private GamePace pace = GamePace.Normal;
        private IFormatProvider format;

        private void Awake()
        {
            pauseButton.onClick.AddListener(Pause);
            normalButton.onClick.AddListener(() => Play());
            fastButton.onClick.AddListener(() => Play(GamePace.Fast));
        }

        private void Start()
        {
            format = CultureInfo.CreateSpecificCulture("en-US");
            DateTime = new(2028, 12, 28, 14, 00, 00);
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
