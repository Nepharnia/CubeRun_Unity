using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    public GameObject Platform_Simple;
    public GameObject Platform_Short;
    public GameObject Platform_Bonus;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float timeBetweenSpawn;

    private float spawnTime;
    private int RandomOption;

    void Start()
    {
        minX = 26.0f;
        maxX = 21.0f;
        minY = -7.0f;
        maxY = 5.5f;
        timeBetweenSpawn = 1.5f;
    }

    // Update is called once per frame
    public void Update()
    {
        
        if(Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        RandomOption = Random.Range(1, 4);

        if (RandomOption == 1)
        {
            Instantiate(Platform_Simple, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
            //Debug.Log("Spawned Option1");
        }
        if (RandomOption == 2)
        {
            Instantiate(Platform_Short, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
            //Debug.Log("Spawned Option2");
        }
        if (RandomOption == 3)
        {
            Instantiate(Platform_Bonus, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
            //Debug.Log("Spawned Option3");
        }
    }

}
