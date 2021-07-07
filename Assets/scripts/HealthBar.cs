using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar playerHealth;
    public Image fillImage;
    private Slider slider;
    public int currentHealth;
    public int maxHealth = 20;


    // Start is called before the first frame update
    void Awake()
    {
        playerHealth = this;
        slider = GetComponent<Slider>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        float fillValue = playerHealth.currentHealth / playerHealth.maxHealth;
        slider.value = fillValue;
    }
}
