using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour  // 게임 운영 코드
{
    // 싱글톤 패턴
    private static GameManager _instance; 
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    private int score;                  // 점수
    private bool stopTrigger = true;    // 장애물을 멈추는 변수

    [SerializeField]
    private GameObject Hack;            // 핵에 대한 그림을 넣기 위한

    [SerializeField]
    private GameObject panel;           // 게임 시작 패널을 넣기 위한

    [SerializeField]
    private GameObject panel2;          // 게임 방향키 패널을 넣기 위한

    [SerializeField]
    private Text scoreTxt;              // 점수 판을 나타내기 위한

    [SerializeField]
    private Text bestScore;             // 최고 점수를 나타내기 위한

    // Start is called before the first frame update4
    // 게임 시작
    void Start()                        
    {
        panel2.SetActive(false);        // 처음 시작시 방향키 패널 안보이게 끔
        score = 0;                      // 점수 0으로 시작
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 게임 종료
    public void GameOver()   
    {
        stopTrigger = false;                                            // 장애물 떨어지는 while문이 그만 실행하게 끔 
        StopCoroutine(CreateRutine());                                  // 장애물 루틴 종료

        if (score > PlayerPrefs.GetInt("BestScore", 0))                 // 최고점수 달성 시
            PlayerPrefs.SetInt("BestScore", score);                     // 최고점수 바꿔주기
        
        bestScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString(); // 최고 점수
        panel2.SetActive(false);                                        // 캐릭터 죽었을 시 방향키 패널 안보이게 끔
        panel.SetActive(true);                                          // 캐릭터 죽었을 시 게임 시작 패널 보이게 끔

        GameManager.Instance.Start();
    }

    public void GameStart()
    {
        stopTrigger = true;                 // 장애물 떨어지는 while문이 실행하게 끔
        StartCoroutine(CreateRutine());     // 장애물 루틴 실행
        panel.SetActive(false);             // 게임 시작 패널 안보이게
        panel2.SetActive(true);             // 게임 방향키 패널 보이게
    }

    // 점수
    public void UpdateScore() 
    { 
        if(stopTrigger)                      
        score++;
        scoreTxt.text = "점수 : " + score; 
    }

    // 장애물 루틴
    IEnumerator CreateRutine()
    {
        while (stopTrigger)
        {
            CreatHack();
            yield return new WaitForSeconds(0.2f);
        }
    }

    // 장애물 생성
    private void CreatHack()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f,1.0f),1.1f,0));
        pos.z = -0.51f;
        Instantiate(Hack, pos, Quaternion.identity); ;
    }
}
