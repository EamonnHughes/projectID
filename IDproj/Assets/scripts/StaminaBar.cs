using System.IO;
using System.Reflection.Emit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
public Slider staminaBar;
private int maxStamina = 20;
private int currentStamina;
public static StaminaBar instance;
private Coroutine regen;

private void Awake()
{
    instance = this;
}
    void Start()
    {
     currentStamina = maxStamina;
     staminaBar.maxValue = maxStamina;
     staminaBar.value = maxStamina;   
    }

    public void UseStamina(int amount){
        if(currentStamina-amount >= 0 ){
            currentStamina -= amount;
            staminaBar.value = currentStamina;
            if(regen != null)
            StopCoroutine(regen);


            regen = StartCoroutine(RegenStam());
        }
        else {
            Debug.Log("Not enough Stamina");
        }
    }

    private IEnumerator RegenStam(){
yield return new WaitForSeconds(2);
while(currentStamina < maxStamina){
    currentStamina += maxStamina/20;
    staminaBar.value = currentStamina;
    yield return new WaitForSeconds(0.1f);
}regen = null;
    }

}
