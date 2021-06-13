using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgro : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    private Vector2 moveDirection;

    public float stopDistance;

    Rigidbody2D rd;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //distance to player 
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if(distToPlayer < agroRange){
            //code to chase player

            ChasePlayer();
        }
        else{
            //stop chesing player
            StopChasing();
        }
    }

    void ChasePlayer(){
        if(Vector2.Distance(transform.position, player.position) > stopDistance){
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }

    void StopChasing(){
        rd.velocity = new Vector2(0,0);
    }
}
