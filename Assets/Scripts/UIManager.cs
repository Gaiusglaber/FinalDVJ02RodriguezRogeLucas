using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public delegate void ResetingScore();
    public event ResetingScore OnResetScore;
    public delegate void WinCondition();
    public event WinCondition OnWin;
    public GameObject resumeButton;
    public GameObject backButton;
    public Player player;
    public Text time;
    public Text score;
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
        if (minutes == 2)
        {
            SceneManagment.GetInstance().win = true;
            OnWin?.Invoke();
        }
        score.text = SceneManagment.GetInstance().highscore.ToString();
        //SceneFade();
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
        GameManager.GetInstance().pause = true;
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
        yield return new WaitForSeconds(2);
        SceneFade();
        yield return null;
    }
    void Resume()
    {
        GameManager.GetInstance().pause = false;
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
