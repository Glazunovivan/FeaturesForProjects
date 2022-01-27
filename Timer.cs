using System.Collections;
using System.Text;  //для StringBuilder
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace EnglishLeague.MiniGame.UI 
{
    public class Timer : MonoBehaviour
    {
        public delegate void TimerDelegate();
        public event TimerDelegate onTimerTickEnd;

        [SerializeField] private Text timeText;

        private Time time;

        public void StartTimer(Time time)
        {
            this.time = time;   //задаем начальное значение
            timeText.text = time.ToString();
            StartCoroutine(Tick());
        }

        private IEnumerator Tick()
        {
            while (time.minute >= 0)
            {
                while (time.second >= 0 && time.second < 60)
                {
                    yield return new WaitForSeconds(1); //каждую секунду
                    time.second--;
                    timeText.text = time.ToString();
                }
                time.second = 59;
                time.minute--;
                timeText.text = time.ToString();
            }
            time.minute = 0;
            time.second = 0;
            timeText.text = time.ToString();

            onTimerTickEnd?.Invoke();   //событие, что таймер кончился
        }
    }



    /// <summary>
    /// Для таймера
    /// </summary>
    [Serializable]
    public struct Time
    {
        public int minute;
        public int second;

        public override string ToString()
        {
            string strMinute = "";
            string strSecond = "";
            if (minute < 10)
            {
                strMinute = "0" + minute.ToString();
            }
            else
            {
                strMinute = minute.ToString();
            }

            if (second < 10)
            {
                strSecond = "0" + second.ToString();
            }
            else
            {
                strSecond = second.ToString();
            }
            return strMinute + ":" + strSecond;
        }
    }
}





