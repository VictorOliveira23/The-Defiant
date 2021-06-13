using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
   
    private Transform player;
    private float dist;
    public float moveSpeed;
    public float howClose;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.position, transform.position);

        if(dist <= howClose){
            transform.LookAt(player);
            GetComponent<Rigidbody2D>().AddForce(transform.forward * moveSpeed);
        }

        //for melee attack or explosive
        if(dist <= 1.5f){
            //do damage or explode
        }
    }
}
