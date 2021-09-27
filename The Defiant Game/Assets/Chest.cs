using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest : MonoBehaviour
{
    [SerializeField] private Sprite closedChest, openChest;
    [SerializeField] SpriteRenderer spriteRenderer;
    public Animator animator;
    public float transitionTime;
    public GameObject lightEffect;
    public GameObject black;


    void Start() {
        spriteRenderer.sprite = closedChest;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Instantiate(lightEffect, transform.position, Quaternion.identity);
        spriteRenderer.sprite = openChest;
        LoadNextLevel();
    }

    public void LoadNextLevel(){
        StartCoroutine(LoadLevel("Ending"));
    }

    IEnumerator LoadLevel(string LevelIndex){
        black.SetActive(true);
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(LevelIndex);

    }

}
