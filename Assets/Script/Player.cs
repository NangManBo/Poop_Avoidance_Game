using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour 
{
    public Rigidbody2D rigidbody;  // Player 개체
    private float speed = 5f;      // 이동 속도
    private float horizontal;      // 수평
    private float vertical;        // 수직
    private bool isDie = false;    // 죽음
    private bool moveLeft = false; // 왼쪽 방향키 입력값 받기
    private bool moveRight = false;// 오른쪽 방향키 입력값 받기

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        PlayerMove();
        ScreenOut();
    }

    private void PlayerMove()
    { 
        rigidbody.velocity = new Vector2(horizontal * speed, rigidbody.velocity.y);
        if (moveLeft)
        {
            rigidbody.velocity = new Vector2(speed * -1, rigidbody.velocity.y);
        }

        if (moveRight)
        {
            rigidbody.velocity = new Vector2(speed * 1, rigidbody.velocity.y);
        }
    }
  
    public void LeftDown()
    {
        moveLeft = true;
    }

    public void LeftUp()
    {
        moveLeft = false;
    }

    public void RightDown()
    {
        moveRight = true;
    }

    public void RightUp()
    {
        moveRight = false;
    }

    private void ScreenOut()
    {
        Vector3 worlpos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worlpos.x < 0.05f) worlpos.x = 0.05f;
        if (worlpos.x > 0.95f) worlpos.x = 0.95f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worlpos);
    }
}
