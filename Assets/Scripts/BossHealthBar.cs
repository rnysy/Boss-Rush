using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Enemy bosshealth;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = bosshealth.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = bosshealth.currentHealth;
    }
}
