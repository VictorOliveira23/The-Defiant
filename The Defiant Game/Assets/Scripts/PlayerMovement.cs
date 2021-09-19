using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    Vector3 moving = new Vector3();

    void Start() {
        moving = transform.position;
    }
    void Update() {
        ProcessInputs();
    }
    void FixedUpdate() {
        Move();
        CharMoved();
    }
    void ProcessInputs(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }
    void Move(){
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        Vector3 characterScale = transform.localScale;
        if(Input.GetAxis("Horizontal") < 0){
            characterScale.x = -1;
        }
        if(Input.GetAxis("Horizontal") > 0){
            characterScale.x = 1;
        }
        transform.localScale = characterScale;
    }
    public void CharMoved()
    {
        if(transform.position != moving)
        {
            var displacement = transform.position - moving;
            moving = transform.position;
            animator.SetBool("isRunning", true);
        }else{
            
            animator.SetBool("isRunning", false);
        }
    }
}
    