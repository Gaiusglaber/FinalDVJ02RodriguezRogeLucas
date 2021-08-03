using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animatorScene;
    public GameObject win;
    public GameObject lose;
    public Text ScoreText;
    private int SceneIndex;
    private void Start()
    {
        if (SceneManagment.GetInstance().win)
        {
            win.SetActive(true);
        }
        else
        { 
            lose.SetActive(true);
        }
        ScoreText.text = SceneManagment.GetInstance().highscore.ToString();
    }
    private void Update()
    {
        SceneFade();
    }
    public void Back()
    {
        StartCoroutine("BackPressed");
    }
    public void SceneFade()
    {
        if (Fade.faded)
        {
            Fade.faded = false;
            SceneManager.LoadScene(SceneIndex);
        }
    }
    public void Next()
    {
        StartCoroutine("NextPressed");
    }
    public void FadeLevel(int SceneToTransition)
    {
        SceneIndex = SceneToTransition;
        animatorScene.SetTrigger("FadeOut");
    }
    IEnumerator NextPressed()
    {
        yield return new WaitForSeconds(1);
        FadeLevel(SceneManager.GetActiveScene().buildIndex -1);
        yield return null;
    }
    IEnumerator BackPressed()
    {
        yield return new WaitForSeconds(1);
        FadeLevel(SceneManager.GetActiveScene().buildIndex - 3);
        yield return null;
    }
}
