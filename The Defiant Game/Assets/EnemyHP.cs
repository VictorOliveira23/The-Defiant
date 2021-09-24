using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    public GameObject bloodEffect;

    void Update() {
        if(health <= 0){
            Destroy(gameObject);
        }     
    }
    public void TakeDamage(int damage){ 
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -=damage;
    }
}
