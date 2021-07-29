using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagment : MonoBehaviour
{
    private void Start()
    {
        GameManager.PlayerDeath += ToNextScene;
    }
    void ToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
