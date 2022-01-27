using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//GIS
//Вешается на префаб награды, работает отлично
public class PopUpGold : MonoBehaviour
{
    [SerializeField] private Text text;

    private AudioSource audioSource;

    public delegate void Click();
    public event Click OnClosedPopupGold;

    private void OnEnable()
    {
        Debug.Log("Открываем pop up gold");
        audioSource = GetComponentInParent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = FindObjectOfType<AudioSource>();
        }
        audioSource.Play();
    }

    private void OnDestroy()
    {
        OnClosedPopupGold?.Invoke();
    }

    public void SetReward(double count)
    {
        string textCount = count.ToString();
        text.text = textCount;
    }

    //для кнопки
    public void Close()
    {
        Destroy(gameObject);    //удаляемся
    }
}
//
