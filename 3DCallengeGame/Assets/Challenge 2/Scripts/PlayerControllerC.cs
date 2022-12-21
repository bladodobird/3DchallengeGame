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
    public Animator playerAnim;
    public ParticleSystem playerEXp; //�W�[�ɤl�z���ĪG
    public ParticleSystem playerDirt;

    public AudioClip soundJump;
    public AudioClip soundCrash;
    private AudioSource playSound;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        //playerRB.AddForce(Vector3.up * 100); //�w�惡����I�O�D.��V * �O�q
        Physics.gravity = Physics.gravity * gravityMod;

        playerAnim = GetComponent<Animator>();
        playSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && !gameOver) //�PgameOver == false
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //isOnGround = false;//���a �ťիظ��D�N�|����
            twiceJump++; // +1���N��
            //print("��������: " + twiceJump);
            playerAnim.SetTrigger("Jump_trig");
            playerAnim.speed = 4;
            playerDirt.Stop();
            playSound.PlayOneShot(soundJump, 2);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            twiceJump = 0;
            //playerAnim.SetFloat("Speed_f", 1);
            playerAnim.speed = 1; //������_�t��
            playerDirt.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            print("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerEXp.Play();
            playerDirt.Stop();

            playSound.PlayOneShot(soundCrash, 1.5f);
        }
    }
}
