using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour 
{
    public Rigidbody2D rigidbody;  // Player ��ü
    private float speed = 5f;      // �̵� �ӵ�
    private float horizontal;      // ����
    private float vertical;        // ����
    private bool isDie = false;    // ����
    private bool moveLeft = false; // ���� ����Ű �Է°� �ޱ�
    private bool moveRight = false;// ������ ����Ű �Է°� �ޱ�

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
