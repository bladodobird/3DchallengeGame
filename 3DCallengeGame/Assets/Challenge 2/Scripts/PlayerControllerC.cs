using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerC : MonoBehaviour
{
    public Rigidbody playerRB;
    public float jumpForce = 10;
    public float gravityMod = 1;
    public bool isOnGround = true;//�P�_���a�O�_�b�a�W

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        //playerRB.AddForce(Vector3.up * 100); //�w�惡����I�O�D.��V * �O�q
        Physics.gravity = Physics.gravity * gravityMod;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;//���a �ťիظ��D�N�|����
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true; 
    }
}
