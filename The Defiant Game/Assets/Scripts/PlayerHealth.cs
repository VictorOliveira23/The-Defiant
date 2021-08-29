using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private Slider healthSlider;

    private void Start() {
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
    }
   
    public void UpdateHealth(float mod){ //this is for if the player picks up a healthpack
        health += mod;
        if(health > maxHealth){
            health = maxHealth;
        }else if(health < mod){
            health = mod;
        }else if(health <= 0){
            health = 0f;
            healthSlider.value = health;
            PlayerDie();
        }
    }
    private void PlayerDie(){
        LevelManager.instance.GameOver();
        gameObject.SetActive(false);
    }
    private void OnGUI() {
        float t = Time.deltaTime / 1f;
        healthSlider.value = Mathf.Lerp(healthSlider.value, health, t);   
    }
}
