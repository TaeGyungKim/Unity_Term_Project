using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{

    private bool isSpawnEasterEgg =false;
    private bool isSpawnBoss =false;
    private bool isEnding =false;
    private GameObject easterEgg;
    private GameObject enemy;
    private GameObject eventCheck;
    private GameObject gameManager;

    private GameObject attentionText;
    private GameObject cautionText;

    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //easterEgg 이벤트 발생 (360,0,0)
        easterEgg= GameObject.Find("EasterEggSpawn").transform.Find("EasterEgg").gameObject;

        //(400,0,130) 자리에서 보스전 시작
        enemy = GameObject.Find("EnemySpawn").transform.Find("Enemy").gameObject;

        //보스 이벤트 발생 확인
        eventCheck = GameObject.Find("BossEventPosition");

        gameManager = GameObject.Find("GameManager");

        attentionText = GameObject.Find("Canvas").transform.Find("attention").gameObject;
        cautionText = GameObject.Find("Canvas").transform.Find("caution").gameObject;

    }

    private void Update()
    {
        if (isSpawnEasterEgg)
        {

            if (time < 3.0f)
            {
                time += Time.deltaTime;
                gameManager.GetComponent<CameraSetting>().changeToCamEvent();
                    attentionText.SetActive(true);
                }
            else
            {
                attentionText.SetActive(false);
                gameManager.GetComponent<CameraSetting>().changeToCam();
            }
                
        }
    }

    //이벤트 위치에서 트리거
    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "unito") return; 

        //첫 이벤트 발생시
        if (!isSpawnEasterEgg)
        {
            easterEgg.SetActive(true);
            isSpawnEasterEgg = true;
        }
        //보스 조우 후 엔딩 이벤트
        else
        {
            isSpawnBoss = eventCheck.GetComponent<BossEvent>().isEventBoss();
            if (!isSpawnBoss) return;

            isEnding = true;
        }
    }

    public bool isEventEasterEgg()
    {
        return isSpawnEasterEgg;
    }

    public bool isEventBoss()
    {
        return isSpawnBoss;
    }

    public bool isEnd()
    {
        return isEnding;
    }

}
