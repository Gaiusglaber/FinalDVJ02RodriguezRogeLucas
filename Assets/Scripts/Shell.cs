using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour,IDestructible
{
    public GameObject explotionPrefab;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);
            SceneManagment.GetInstance().highscore += 200;
        }else if (collision.transform.CompareTag("Box"))
        {
            SceneManagment.GetInstance().highscore += 50;
            Destroy(collision.gameObject);
        }
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
