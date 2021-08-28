using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDamage : MonoBehaviour
{

    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;

    private void OnCollisionStay2D(Collision2D damage) {
        if(damage.gameObject.tag == "Player"){
            if(attackSpeed <= canAttack){
                Debug.Log("HIT!");
                damage.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }else{
                canAttack += Time.deltaTime;
            }
           
        }
    }
}
