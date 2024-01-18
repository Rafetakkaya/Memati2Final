using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime = 300f; // 5 dakika (300 saniye)
    private float currentTime;

    public TextMeshProUGUI timerText;

    void Start()
    {
        currentTime = totalTime;
    }

    void Update()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            DisplayTime();
        }
        else
        {
            SceneManager.LoadScene("LastScreen");
        }
    }

    void DisplayTime()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Zamanı Text elemanına yazdır
        timerText.text = "Kalan Zaman: " + timeString;


    }
}