using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : MonoBehaviour
{
   
    public float attackRange;
    public Transform player;
    public Transform enemy;
    public Animator animator;
    public float cooldownTime = 2f;
    private float nextFireTime = 0;
    public int damage = 10;
    public Transform attackPos,shootPos;
    public GameObject slimeBall;
    public float shootSpeed;


   
/*
    private void OnCollisionEnter2D(Collision2D damage) {
        if(damage.gameObject.tag == "Player"){
            if(attackSpeed <= canAttack){
                Debug.Log("HIT! enter ");
                damage.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }else{
                canAttack += Time.deltaTime;
            }
        }
    }
*/
    void Update() {

    if(Vector2.Distance(player.position, enemy.position) <= attackRange){
        if(Time.time > nextFireTime){
            animator.SetTrigger("isAttacking");
            nextFireTime = Time.time + cooldownTime;
        }
    }    
/*
        if(Vector2.Distance(player.position, enemy.position) <= attackRange){
            if(TimeBtwAttack <= 0){
                animator.SetTrigger("isAttacking");
                TimeBtwAttack = startTimeBtwAttack;
            }else{
                TimeBtwAttack -= Time.deltaTime;
            }      
        }
*/
    }

    public void enemySlimeAttack(){
            Instantiate(slimeBall, shootPos.position, Quaternion.identity);
            //newSlimeBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * Time.fixedDeltaTime, shootSpeed * Time.fixedDeltaTime);

            
            //GameObject.FindObjectOfType<PlayerHealth>().UpdateHealth(-damage);
        
    }
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    
    /*
    private void OnCollisionStay2D(Collision2D damage) {
        if(damage.gameObject.tag == "Player"){
            if(attackSpeed <= canAttack){
                //Debug.Log("HIT! stay");
                damage.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }else{
                canAttack += Time.deltaTime;
            }
           
        }
    }*/
}
