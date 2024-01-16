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
        if (collision.gameObject.tag == "Ground")  // 땅과 부딪히면 점수
        {
            GameManager.Instance.UpdateScore();
            Destroy(this.gameObject);    
        }

        if(collision.gameObject.tag == "Player")   // 캐릭터와 부딪히면 게임종료
        {
            GameManager.Instance.GameOver();
            Destroy(this.gameObject);
        }
    }

}
