using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentTime;
    public float startingTime = 10f;
    public TextMeshProUGUI countdownText;
    public GameObject DeathScreen;
    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else if (currentTime < 0)
        {
            currentTime = 0;
            // Add here whatever needs to happen after the timer ends
            DeathScreen.SetActive(true);
            if (DeathScreen.activeInHierarchy == false)
            {
                currentTime = startingTime;
            }
        }

        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
