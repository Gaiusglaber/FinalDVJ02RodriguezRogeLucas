using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public GameObject boxPrefab;
    public GameObject bombPrefab;

    private float timerBoxSpawn=20;

    private float timerBombSpawn = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerBoxSpawn -= Time.deltaTime;
        timerBombSpawn -= Time.deltaTime;
        if (timerBoxSpawn <= 0f)
        {
            for (int i = 0; i < Random.Range(1, 4); i++)
            {
                GameObject instantiator_box = Instantiate(boxPrefab,
                    new Vector3(Random.Range(100, 300), 5, Random.Range(275, 425)), Quaternion.identity).gameObject;
            }
            timerBoxSpawn = 20;
        }
        if (timerBombSpawn <= 0f)
        {
            for (int i = 0; i < Random.Range(1, 4); i++)
            {
                GameObject instantiator_bomb = Instantiate(bombPrefab,
                    new Vector3(Random.Range(100, 300), 5, Random.Range(275, 425)), Quaternion.identity).gameObject;
            }
            timerBombSpawn = 10;
        }
    }
}
