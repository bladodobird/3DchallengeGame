using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 25;
    public PlayerControllerC PC_Script; //�ŧi�@�өMPlayerConcroller3�@�˫��A���ܼ�

    void Start()
    {
        PC_Script = GameObject.Find("Player").GetComponent<PlayerControllerC>();
    }

    void Update()
    {
        // gameaover���ҰʴN���򲾰�
        if (PC_Script.gameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

    }
}
