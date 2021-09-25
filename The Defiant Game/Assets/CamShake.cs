using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public Animator cam;
    public void Cam(){
        cam.SetTrigger("Shake");
    }
}
