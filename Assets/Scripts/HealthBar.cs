using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 100;
        fill.color = gradient.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value -= 0.5f;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
