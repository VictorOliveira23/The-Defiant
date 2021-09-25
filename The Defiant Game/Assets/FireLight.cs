using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class FireLight : MonoBehaviour
{
    Light2D light2D;
    public float InnerOne;
    public float InnerTwo; 
    public float betweenFlicker;

    private void Start() {
        light2D = GetComponent<Light2D>();
        StartCoroutine(LightFlicker());
    }
   
    IEnumerator LightFlicker(){
        yield return new WaitForSeconds(betweenFlicker);
        light2D.pointLightInnerRadius = Random.Range(InnerOne, InnerTwo);
        StartCoroutine(LightFlicker());
    }

}
