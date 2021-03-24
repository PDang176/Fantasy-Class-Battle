using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Text health_text;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        health_text.text = health.ToString() + "/" + health.ToString();
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        health_text.text = health.ToString() + "/" + slider.maxValue;
    }
}
