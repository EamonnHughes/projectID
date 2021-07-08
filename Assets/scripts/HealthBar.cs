using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
        public Slider healthBar;
    public int maxHealth = 20;
    public int currentHealth;
    public static HealthBar instance;


    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = maxHealth;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int amount){
        if (currentHealth - amount > 0)
        {
                 healthBar.value = currentHealth;
            currentHealth -= amount;
        }else{
            Debug.Log("GameOver");
        }
    }
}
