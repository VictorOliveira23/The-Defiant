using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward)*5550,Color.red,2f);

    }
}
