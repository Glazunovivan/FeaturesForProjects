using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpStars : MonoBehaviour
{
    private AudioSource audioSource;

    public delegate void Click();
    public event Click OnClosePopup;

    private void OnEnable()
    {
        Debug.Log("Включилась музыка при прохождении мини игры");
        audioSource = GetComponentInParent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = FindObjectOfType<AudioSource>();
        }
        audioSource.Play();
    }

    private void OnDestroy()
    {
        OnClosePopup?.Invoke();
    }

    public void Close()
    {
        Destroy(gameObject);
    }
}
