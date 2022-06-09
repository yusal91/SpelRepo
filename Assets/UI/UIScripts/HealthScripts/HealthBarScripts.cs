using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScripts : MonoBehaviour
{
    public Slider hpSlider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        hpSlider.maxValue = health;
        hpSlider.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        hpSlider.value = health;
        fill.color = gradient.Evaluate(hpSlider.normalizedValue);
    }
}
