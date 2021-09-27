using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : MonoBehaviour
{
    public float dieTime, damage,missTime;
    public GameObject dieButtle;
    
    public float speed;
    private Transform player;
    private Vector2 targat;
    private Rigidbody2D rb2D;
    public GameObject ballExplode;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        targat = new Vector2(player.position.x, player.position.y);
        rb2D = GetComponent<Rigidbody2D>();
        StartCoroutine(CountDownTimer());
    }

    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, targat, speed * Time.deltaTime);
        if(transform.position.x == targat.x && transform.position.y == targat.y){
            StartCoroutine(CountDownMiss());            
        }    
        
    }
    private void OnTriggerStay2D(Collider2D other) {
         if(other.CompareTag("Player")){
            GameObject.FindObjectOfType<PlayerHealth>().UpdateHealth(-damage);
            DestroyProjectile();
        }
    }
    void DestroyProjectile(){
        Instantiate(ballExplode, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    IEnumerator CountDownTimer(){
        yield return new WaitForSeconds(dieTime);
        DestroyProjectile();
    }
    IEnumerator CountDownMiss(){

        yield return new WaitForSeconds(missTime);
        DestroyProjectile();
    }

}
