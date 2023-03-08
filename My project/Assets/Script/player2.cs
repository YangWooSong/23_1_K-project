using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{
      Rigidbody2D rigid;
    public float maxSpeed;
    public float jumpPower;
/*    SpriteRenderer spriteRenderer;*/


    void Awake()
    {
        rigid= GetComponent<Rigidbody2D>();
/*        spriteRenderer = GetComponent<SpriteRenderer>();*/
    }
    void Update()
    {
        //Jump
        if(Input.GetButtonDown("Jump")/* && !Animation.GetBool("isJumping")*/) 
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
/*        //멈출때 속도
        if (Input.GetButtonDown("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }*/
    }


    void FixedUpdate()
    {
        //움직일때 속도
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if(rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if(rigid.velocity.x < maxSpeed*(-1)) 
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }

        //착지했을 때 바닥 감지
        if(rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Floor"));

            if (rayHit.collider != null)
            {
                /*            if (rayHit.distance < 0.5f)
                            {
                                anim. 착지 애니메이션28:50
                            }*/
            }
        }
}
