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

    public void TakeDamage(int amount)
    {
        if (currentHealth - amount > -1)
        {
            healthBar.value = currentHealth;
            currentHealth -= amount;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "prokectile")
        {
            HealthBar.instance.TakeDamage(1);
            Destroy(collision.gameObject);
            Debug.Log("collide");
        }
        else
        {
            Debug.Log("collide2 " + collision.gameObject.tag);
        }
    }
}
