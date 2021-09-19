using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockForce : MonoBehaviour
{
    public Rigidbody2D rigidBody;      
    private void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() {
        rigidBody.velocity -= rigidBody.velocity / 30f;
        rigidBody.angularDrag = 1F;
    }
}
