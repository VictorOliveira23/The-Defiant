using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_behaviour : MonoBehaviour
{
    #region Public Variables
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLenght;
    public float attackDistance; //distance for attack
    public float timer; //Timer for cooldown between attacks
    #endregion

    #region Private Variables
    private GameObject target;
    private Animator animator;
    private float distance; //Store the distance b/w enemy and player
    private bool attackMode;
    private bool inRange; //Check if player is in range
    private bool cooling; //Cooldown for each attack
    private float intTimer;
    #endregion

    void Awake() {
        intTimer = timer; //Store the inital value of timer
        animator = GetComponent<Animator>();

    }

    void Update()
    { 
        if(inRange){
           // hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLenght, raycastMask);
            RaycastDebugger();
        }
    }

    void OnTriggerEnter2D(Collider2D trigger) {
        if(trigger.gameObject.tag == "Player")
        {
            target = trigger.gameObject;
            inRange = true;
        }
    }
    void RaycastDebugger(){
        if(distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLenght, Color.red);
        }else if(attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLenght, Color.green);
        }
    }
}
