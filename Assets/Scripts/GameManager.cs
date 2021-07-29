using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public delegate void OnGameEnded();
    public static event OnGameEnded PlayerDeath;
    // Start is called before the first frame update
    void Start()
    {
        player.OnPlayerDestroyed += EndGame;
    }
    private void OnDisable()
    {
        player.OnPlayerDestroyed -= EndGame;
    }
    void EndGame()
    {
        PlayerDeath?.Invoke();
    }
    // Update is called once per frame
}
