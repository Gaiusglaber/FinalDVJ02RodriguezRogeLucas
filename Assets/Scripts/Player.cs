using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IDestructible
{
    public float speed;
    public delegate void OnDestroyed();
    public event OnDestroyed OnPlayerDestroyed;
    public delegate void Following();
    public event Following OnFollowingPlayer;
    void Start()
    {
        
    }
    void MovementManager()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        if (movementDirection != Vector3.zero)
        {
            transform.forward = movementDirection;
        }
    }
    // Update is called once per frame
    void Update()
    {
        OnFollowingPlayer?.Invoke();
        MovementManager();
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
