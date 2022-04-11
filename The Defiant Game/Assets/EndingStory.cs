using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingStory : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Menu");
    }
}
