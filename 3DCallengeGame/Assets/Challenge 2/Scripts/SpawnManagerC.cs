using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerC : MonoBehaviour
{
    public GameObject obstaclePrbfab;
    public Vector3 spawnPos = new Vector3(25, 0, 0);

    public float delayTime = 1.5f;
    public float repeatTime = 2;

    public PlayerControllerC PC_Script;

    void Start()
    {
        InvokeRepeating("ObstacleSpawn", delayTime, repeatTime);
        PC_Script = GameObject.Find("Player").GetComponent<PlayerControllerC>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ObstacleSpawn()
    {
        if (PC_Script.gameOver == false) //遊戲結束前持續生成
        {
            Instantiate(obstaclePrbfab, spawnPos, obstaclePrbfab.transform.rotation);
        }


    }
}
