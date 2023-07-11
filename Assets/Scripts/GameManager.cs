using System;
using UnityEngine;

namespace Initium
{
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            Time.OnDayPassed += (string day) =>
            {
                Debug.Log($"A new day emerges... It is now {day}.");
            };

            Time.OnYearPassed += (int year) =>
            {
                Debug.Log($"A year has passed... It is now year {year}.");
            };
        }
    }
}
