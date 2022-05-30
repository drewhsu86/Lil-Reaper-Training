using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    Slider slider;

    void Start() {
        slider = gameObject.GetComponent<Slider>();
    }

    // public method to allow health to affect slider UI
    public void SetHealth(float hp) {
        if (slider != null) slider.value = hp;
    }
}
