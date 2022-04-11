using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public static Knockback instance;
    //Player component references
    public Rigidbody2D rigidbody2D;
    public float thrust = 20f;

    public bool isHurt{
        get {return isHurt;}
    }
    //bool isHurt = false;
    private void Awake() {
        instance = this;
    }
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

   
    public void UpdateKock(float KnockbackDuration, float KnockbackPower,Transform obj){
        Vector2 direction = (obj.transform.position - this.transform.position).normalized;
        rigidbody2D.AddForce(-direction * 300);
     


        //Vector2 test = transform.position;
    
        //rigidbody2D.velocity -= new Vector2(transform.position.x + test.x, transform.position.y + test.y / 30f);
        //rigidbody2D.angularDrag = 1F;
    }
}
