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
    public Animator playerAnim;
    public ParticleSystem playerEXp; //增加粒子爆炸效果
    public ParticleSystem playerDirt;

    public AudioClip soundJump;
    public AudioClip soundCrash;
    private AudioSource playSound;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        //playerRB.AddForce(Vector3.up * 100); //針對此鋼體施力道.方向 * 力量
        Physics.gravity = Physics.gravity * gravityMod;

        playerAnim = GetComponent<Animator>();
        playSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && !gameOver) //同gameOver == false
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //isOnGround = false;//離地 空白建跳躍就會失效
            twiceJump++; // +1的意思
            //print("跳的次數: " + twiceJump);
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
            playerAnim.speed = 1; //降落恢復速度
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
