using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")  // ���� �ε����� ����
        {
            GameManager.Instance.UpdateScore();
            Destroy(this.gameObject);    
        }

        if(collision.gameObject.tag == "Player")   // ĳ���Ϳ� �ε����� ��������
        {
            GameManager.Instance.GameOver();
            Destroy(this.gameObject);
        }
    }

}
