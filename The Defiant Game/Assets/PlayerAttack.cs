using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    private float TimeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;

    private CamShake camShake;

    void Start() {
            
    }
    // Update is called once per frame
    void Update()
    {
        if(TimeBtwAttack <= 0){
            //now you can attack after the time as passed
            if(Input.GetKey(KeyCode.Space)){
                camShake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CamShake>();
                animator.SetTrigger("isAttacking");
            }
        }else{
            TimeBtwAttack -= Time.deltaTime;
        }
    }

    public void playerAttack(){
            Collider2D[] enemiesDm = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            for(int i = 0; i < enemiesDm.Length; i++){
                enemiesDm[i].GetComponent<EnemyHP>().TakeDamage(damage);
                camShake.Cam();
            }
            TimeBtwAttack = startTimeBtwAttack;
    }
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
