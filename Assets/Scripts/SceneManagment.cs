using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagment : MonoBehaviour
{
    #region SINGLETON
    static private SceneManagment instance;
    static public SceneManagment GetInstance() { return instance; }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
    public int highscore;
    public bool win;
    public float distance;
    private void Start()
    {
        GameManager.PlayerDeath += GameOver;
    }

    public void GameOver()
    {
        
        GameObject animatorScene = GameObject.FindGameObjectWithTag("SceneTransition");
        if (animatorScene != null)
        {
            animatorScene.GetComponent<Animator>().SetTrigger("FadeOut");
            StartCoroutine("Transition");
        }
    }
    public void TransitionToNewScene()
    {
        if (Fade.faded)
        {
            Fade.faded = false;
            SceneManager.LoadScene(3);
        }
    }
    IEnumerator Transition()
    {
        yield return new WaitForSeconds(2);
        TransitionToNewScene();
        yield return null;
    }
}
