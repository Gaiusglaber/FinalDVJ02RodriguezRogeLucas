using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    #region SINGLETON
    static private GameManager instance;
    static public GameManager GetInstance() { return instance; }
    #endregion
    public Player player;
    public UIManager uimanager;
    public delegate void OnGameEnded();
    public static event OnGameEnded PlayerDeath;
    // Start is called before the first frame update
    void Start()
    {
        player.OnPlayerDestroyed += EndGame;
        uimanager.OnResetScore += ResetScore;
    }
    private void OnDisable()
    {
        PlayerDeath?.Invoke();
        player.OnPlayerDestroyed -= EndGame;
        uimanager.OnResetScore -= ResetScore;
    }
    public void ResetScore()
    {
        SceneManagment.GetInstance().highscore = 0;
    }
    void EndGame()
    {
        PlayerDeath?.Invoke();
    }
    // Update is called once per frame
}
