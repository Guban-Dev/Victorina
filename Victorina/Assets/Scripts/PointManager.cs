using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class PointManager : MonoBehaviour
    {
        public static PointManager instance;
        [Header("Set in Inspector")]
        public TextMeshProUGUI uitTotalPoints;
        public TextMeshProUGUI uitScoreSpeed;

        [Header("Set in dinamically")]
        private int _rateSpeedPoints;
        public static int[] points = new int[6];
        public static float[] SpeedPoints = new float[6];
        private GameManager gameManager;
        public  int totalPoints;
        public static int numCategory;

        private void Awake()
        {
            gameManager = GetComponent<GameManager>();
        }

        private void Start()
        {
            instance = this;
            _rateSpeedPoints = 20000;
            SetPoitsTxt();
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print(TotalPoints());
            }
        }

        public void SetScoreSpeedTxt()
        {
            uitScoreSpeed.text = TotalSpeedPoints().ToString();
        }

        public float TotalSpeedPoints()
        {
            float total = 0;

            for (int i = 0; i < SpeedPoints.Length; i++)
            {
                if (SpeedPoints[i] != 0) total += _rateSpeedPoints / SpeedPoints[i];
            }

            return MathF.Round(total);
        }

        public void SetPoitsTxt()
        {
            uitTotalPoints.text = TotalPoints().ToString() + " из " + totalPoints.ToString();
        }

        public static int TotalPoints()
        {
            int total = 0;
            for (int i = 0; i < points.Length; i++) total += points[i];

            return total;
        }

        public void SetSpeedPoints()
        {
            if (TimerManager._timer >= 20000) TimerManager._timer = 20000;

            int penaltyTime = (gameManager.QuestionsCount[gameManager.CategoryNum] - points[gameManager.CategoryNum]) * 10;
            TimerManager.AddTimer(penaltyTime);

            if (SpeedPoints[gameManager.CategoryNum] == 0)
            {
                SpeedPoints[gameManager.CategoryNum] = Mathf.Floor(TimerManager._timer);
            }
            else
            {
                if (SpeedPoints[gameManager.CategoryNum] > TimerManager._timer)
                {
                    SpeedPoints[gameManager.CategoryNum] = Mathf.Floor(TimerManager._timer);
                }
            }
        }

        public void ClearSpeedPoint()
        {
            for (int i = 0; i < SpeedPoints.Length; i++)
            {
                SpeedPoints[i] = 0;
            }
        }

        public void SetTotalPoints()
        {
            for (int i = 0; i < gameManager.Categories.Length; i++)
            {
                totalPoints += gameManager.Categories[i].Questions.Length;
            }
        }
    }
}