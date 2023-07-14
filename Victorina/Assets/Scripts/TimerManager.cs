using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class TimerManager : MonoBehaviour
    {
        public static TimerManager instance;
        [Header("Set in Inspector")]
        public TextMeshProUGUI uitTimer;

        [Header("Set in dinamically")]
        public static bool _onTimer;
        public static float _timer;

        private void Awake()
        {
            instance = this;
        }

        private void FixedUpdate()
        {
            if (_onTimer)
            {
                _timer += Time.deltaTime;
                uitTimer.text = _timer.ToString("F0");
            }
        }

        public static void AddTimer(float value)
        {
            _timer += value;
        }

        public static void SubtractTimer(float value)
        {
            if (_timer - value <= 0) _timer = 0;
            else _timer -= value;
        }
    }
}