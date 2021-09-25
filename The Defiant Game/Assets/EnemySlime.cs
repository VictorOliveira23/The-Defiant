using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : MonoBehaviour
{
    public float dieTime, damage;
    public GameObject dieButtle;
    
    public float speed;
    private Transform player;
    private Vector2 targat;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        targat = new Vector2(player.position.x, player.position.y);
        StartCoroutine(CountDownTimer());
    }

    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, targat, speed * Time.deltaTime);
        if(transform.position.x == targat.x && transform.position.y == targat.y){
            DestroyProjectile();
        }    
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            DestroyProjectile();
        }
    }
    void DestroyProjectile(){
        Destroy(gameObject);
    }

    IEnumerator CountDownTimer(){
        yield return new WaitForSeconds(dieTime);
        Destroy(gameObject);
    }

}
