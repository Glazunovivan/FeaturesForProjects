using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Главный скрипт для 4й мини игры
/// </summary>
namespace MiniGame.Four
{
    public class Main : MonoBehaviour
    {
        [Header("Награда за одну стадию")]
        public double Reward;

        [SerializeField] private List<GameObject> stages;   //стадии

        [Header("Звуки")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip longWin;
        [SerializeField] private AudioClip shortWin;
        [SerializeField] private AudioClip winMiniGame;

        [Header("PopUp с монетами")]
        [SerializeField] private GameObject popUpGold;
        [SerializeField] private Transform transformPopUpGold;

        [Header("PopUp со звездами")]
        [SerializeField] private GameObject popUpStars;
        [SerializeField] private Transform transformPopUpStars;

        private int currentStage;
        private Money money;

        private void Start()
        { 
            currentStage = 0;
            if (stages.Count < 1)
            {
                Debug.Log("Не назначены стадии мини игр!");
            }
        }

        public void PlayAudioShortWin()
        {
            audioSource.clip = shortWin;
            audioSource.Play();
        }

        public void PlayAudioLongWin()
        {
            audioSource.clip = longWin;
            audioSource.Play();
        }

        public void Popup()
        {
            currentStage++;

            SetAudio(longWin);
            var obj = Instantiate(popUpGold, transformPopUpGold);
            obj.GetComponent<PopUpGold>().SetReward(Reward);
            obj.GetComponent<PopUpGold>().OnClosedPopupGold += Next;
            money.Add_Money(Reward);
        }

        private void Next()
        {
            Debug.Log("Следующая стадия");
            if (currentStage < stages.Count)
            {
                stages[currentStage - 1].SetActive(false);
                stages[currentStage].SetActive(true);
            }
            if (currentStage == stages.Count)
            {
                SetAudio(winMiniGame);
                var obj = Instantiate(popUpStars, transformPopUpStars);
                obj.GetComponent<PopUpStars>().OnClosePopup += Finish;
            }
        }

        private void SetAudio(AudioClip audio)
        {
            audioSource.clip = audio;
        }

        private void Finish()
        {
            Debug.Log("Конец мини игры 4");
            gameObject.SetActive(false);
        }

        public void UseClue()
        {
            Reward = money.Remove_Money(Reward);
        }

        public void SetMoney()
        {
            money = new Money();
            money.SetMoney(Reward);
        }
    }
}

