using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour,IDestructible
{
    public GameObject explotionPrefab;
    public void OnCollisionEnter(Collision collision)
    {
        Destroy();
        Destroy(gameObject);
    }
    public void Destroy()
    {
        
    }
    void OnDisable()
    {
        if (!this.gameObject.scene.isLoaded) return;
        Instantiate(explotionPrefab, new Vector3(transform.position.x, transform.position.y+1, transform.position.z), Quaternion.identity);
    }
}
