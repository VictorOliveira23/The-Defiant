using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    [SerializeField] private float HpPotion = 30f;

    private void OnCollisionStay2D(Collision2D player) {
        if(player.gameObject.tag == "Player"){
            player.gameObject.GetComponent<PlayerHealth>().UpdateHealth(+HpPotion);
            Destroy(gameObject);
        }
    }
}
