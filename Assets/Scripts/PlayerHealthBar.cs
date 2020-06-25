using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = playerHealth.health;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = playerHealth.currentHealth;
    }
}
