using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{

    private Animator animator;
    Vector3 moving = new Vector3();
    
    // Start is called before the first frame update
    void Start()
    {
        moving = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CharMoved();
    }

    public void CharMoved()
    {
        if(transform.position != moving)
        {
            var displacement = transform.position - moving;
            moving = transform.position;
            animator.SetBool("isRunning", true);

            //Debug.Log(moving);
        }else{
            
            animator.SetBool("isRunning", false);
            //Debug.Log(moving);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        animator.SetBool("isAttacking", true);
    }

    private void OnTriggerExit2D(Collider2D collider) {
        animator.SetBool("isAttacking", false);
    }
}
