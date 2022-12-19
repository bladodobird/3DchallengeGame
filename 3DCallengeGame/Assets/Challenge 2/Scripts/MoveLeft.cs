using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 25;
    public PlayerControllerC PC_Script; //宣告一個和PlayerConcroller3一樣型態的變數

    void Start()
    {
        PC_Script = GameObject.Find("Player").GetComponent<PlayerControllerC>();
    }

    void Update()
    {
        // gameaover未啟動就持續移動
        if (PC_Script.gameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

    }
}
