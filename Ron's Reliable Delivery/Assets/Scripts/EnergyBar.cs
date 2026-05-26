using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public static EnergyBar instance;
    public Slider timerSlider;
    public float maxTime = 60f;
    public float timePerCollectible = 10f;

    private float currentTime;

    void Start()
    {
        currentTime = maxTime;
        UpdateSlider();
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateSlider();
        }
        else
        {
            SceneManager.LoadScene("Lose Screen");
        }
    }

    public void CollectibleCollected()
    {
        currentTime += timePerCollectible;
        if (currentTime > maxTime)
            currentTime = maxTime;

        UpdateSlider();
    }

    void UpdateSlider()
    {
        timerSlider.value = currentTime / maxTime;
    }
}
