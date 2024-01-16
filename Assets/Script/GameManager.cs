using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour  // ���� � �ڵ�
{
    // �̱��� ����
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

    private int score;                  // ����
    private bool stopTrigger = true;    // ��ֹ��� ���ߴ� ����

    [SerializeField]
    private GameObject Hack;            // �ٿ� ���� �׸��� �ֱ� ����

    [SerializeField]
    private GameObject panel;           // ���� ���� �г��� �ֱ� ����

    [SerializeField]
    private GameObject panel2;          // ���� ����Ű �г��� �ֱ� ����

    [SerializeField]
    private Text scoreTxt;              // ���� ���� ��Ÿ���� ����

    [SerializeField]
    private Text bestScore;             // �ְ� ������ ��Ÿ���� ����

    // Start is called before the first frame update4
    // ���� ����
    void Start()                        
    {
        panel2.SetActive(false);        // ó�� ���۽� ����Ű �г� �Ⱥ��̰� ��
        score = 0;                      // ���� 0���� ����
    }

    // Update is called once per frame
    void Update()
    {

    }

    // ���� ����
    public void GameOver()   
    {
        stopTrigger = false;                                            // ��ֹ� �������� while���� �׸� �����ϰ� �� 
        StopCoroutine(CreateRutine());                                  // ��ֹ� ��ƾ ����

        if (score > PlayerPrefs.GetInt("BestScore", 0))                 // �ְ����� �޼� ��
            PlayerPrefs.SetInt("BestScore", score);                     // �ְ����� �ٲ��ֱ�
        
        bestScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString(); // �ְ� ����
        panel2.SetActive(false);                                        // ĳ���� �׾��� �� ����Ű �г� �Ⱥ��̰� ��
        panel.SetActive(true);                                          // ĳ���� �׾��� �� ���� ���� �г� ���̰� ��

        GameManager.Instance.Start();
    }

    public void GameStart()
    {
        stopTrigger = true;                 // ��ֹ� �������� while���� �����ϰ� ��
        StartCoroutine(CreateRutine());     // ��ֹ� ��ƾ ����
        panel.SetActive(false);             // ���� ���� �г� �Ⱥ��̰�
        panel2.SetActive(true);             // ���� ����Ű �г� ���̰�
    }

    // ����
    public void UpdateScore() 
    { 
        if(stopTrigger)                      
        score++;
        scoreTxt.text = "���� : " + score; 
    }

    // ��ֹ� ��ƾ
    IEnumerator CreateRutine()
    {
        while (stopTrigger)
        {
            CreatHack();
            yield return new WaitForSeconds(0.2f);
        }
    }

    // ��ֹ� ����
    private void CreatHack()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f,1.0f),1.1f,0));
        pos.z = -0.51f;
        Instantiate(Hack, pos, Quaternion.identity); ;
    }
}
