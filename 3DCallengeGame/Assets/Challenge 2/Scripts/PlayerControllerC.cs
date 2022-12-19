using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerC : MonoBehaviour
{
    public Rigidbody playerRB;
    public float jumpForce = 10;
    public float gravityMod = 0;

    public bool isOnGround = true;//判斷玩家是否在地上
    public int twiceJump = 1;

    public bool gameOver = false;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        //playerRB.AddForce(Vector3.up * 100); //針對此鋼體施力道.方向 * 力量
        Physics.gravity = Physics.gravity * gravityMod;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && twiceJump < 2)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //isOnGround = false;//離地 空白建跳躍就會失效
            twiceJump++; // +1的意思
            print("跳的次數: " + twiceJump);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            twiceJump = 0;
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            print("Game Over");
        }
    }
}
