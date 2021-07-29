using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IDestructible
{
    public delegate void OnDestroyed();
    public event OnDestroyed OnPlayerDestroyed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDestroy()
    {
        Destroy();
        OnPlayerDestroyed?.Invoke();
    }
    public void Destroy()
    {

    }
}
