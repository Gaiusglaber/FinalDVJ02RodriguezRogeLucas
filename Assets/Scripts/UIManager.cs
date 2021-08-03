using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public delegate void ResetingScore();
    public event ResetingScore OnResetScore;

    public GameObject resumeButton;
    public GameObject backButton;
    public Player player;
    public Text time;
    public Animator animatorScene;
    private int SceneIndex;
    private float seconds=0;
    private int minutes=0;
    void Start()
    {

    }
    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= 60)
        {
            seconds = 0;
            minutes++;
        }
        time.text = minutes.ToString() + ": " + ((int)(seconds)).ToString()+ "/2:00";
        SceneFade();
    }
    public void SceneFade()
    {
        if (Fade.faded)
        {
            Fade.faded = false;
            SceneManager.LoadScene(SceneIndex);
        }
    }
    public void PauseButtonPressed()
    {
        resumeButton.SetActive(true);
        backButton.SetActive(true);
    }
    public void BackButtonPressed()
    {
        StartCoroutine("GoBack");
    }
    public void ResumeButtonPressed()
    {
        StartCoroutine("ResumeButton");
    }
    public void FadeLevel(int SceneToTransition)
    {
        SceneIndex = SceneToTransition;
        animatorScene.SetTrigger("FadeOut");
    }
    IEnumerator GoBack()
    {
        yield return new WaitForSeconds(1);
        OnResetScore?.Invoke();
        FadeLevel(SceneManager.GetActiveScene().buildIndex - 2);
        yield return null;
    }
    void Resume()
    {
        resumeButton.SetActive(false);
        backButton.SetActive(false);
    }
    IEnumerator ResumeButton()
    {
        yield return new WaitForSeconds(1);
        Resume();
        yield return null;
    }
}
