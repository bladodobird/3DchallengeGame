using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerC : MonoBehaviour
{
    public GameObject obstaclePrbfab;
    public Vector3 spawnPos = new Vector3(25, 0 ,0);

    public float delayTime = 1.5f;
    public float repeatTime = 2;

    void Start()
    {
        InvokeRepeating("ObstacleSpawn", delayTime, repeatTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ObstacleSpawn()
    {
        Instantiate(obstaclePrbfab, spawnPos, obstaclePrbfab.transform.rotation);
    }
}
