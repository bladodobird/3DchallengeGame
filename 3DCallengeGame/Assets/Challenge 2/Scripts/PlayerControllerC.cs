using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerC : MonoBehaviour
{
    public Rigidbody playerRB;
    public float jumpForce = 10;
    public float gravityMod = 0;

    public bool isOnGround = true;//�P�_���a�O�_�b�a�W
    public int twiceJump = 1;

    public bool gameOver = false;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        //playerRB.AddForce(Vector3.up * 100); //�w�惡����I�O�D.��V * �O�q
        Physics.gravity = Physics.gravity * gravityMod;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && twiceJump < 2)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //isOnGround = false;//���a �ťիظ��D�N�|����
            twiceJump++; // +1���N��
            print("��������: " + twiceJump);
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
