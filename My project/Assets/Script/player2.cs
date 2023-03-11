using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{
    Rigidbody2D rigid;
    public Animator animator;
    public float maxSpeed;
    public float jumpPower;
    private bool isjump = true;
    private bool isJump = true;
    private bool isDie = false;
    /*    private bool isPlayer = true;*/

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.W) && isjump)/*isPlayer  && !Animation.GetBool("isJumping")*/ //�����̽��ٸ� ������, ĳ���Ͱ� ���� �ִٸ�
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isjump = false;
            /*isPlayer= false;*/
        }
        //���⶧ �ӵ�
        if (Input.GetButtonDown("Left Right Arrow"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("IsJumping", true);
        }
        else animator.SetBool("IsJumping", false);

        if (Input.GetButton("Left Right Arrow"))
        {
            animator.SetBool("IsWalking", true);
        }
        else animator.SetBool("IsWalking", false);

    }


    void FixedUpdate()
    {
        //�����϶� �ӵ�
        float h = Input.GetAxisRaw("Left Right Arrow");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed * (-1))
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor" /*&& other.gameObject.tag == "Player"*/)
        {
            isjump = true;
            /*isPlayer = true;*/
        }
    }

    void OnTriggerEnter2D(Collider2D other)
     {
        
        if (other.gameObject.tag == "Head")
        {
            isjump = true;
        }
    }
 
}
