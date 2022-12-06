using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEvent : MonoBehaviour
{
    private bool isSpawnEasterEgg = false;
    private bool isSpawnBoss =false;
    private bool isDisableEasterEgg = false;
    private GameObject easterEgg;
    private GameObject enemy;
    private GameObject eventCheck;
    private GameObject gameManager;
    private GameObject cautionText;
    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //easterEgg 이벤트 발생 (360,0,0)
        easterEgg = GameObject.Find("EasterEggSpawn").transform.Find("EasterEgg").gameObject;
        //(400,0,130) 자리에서 보스전 시작
        enemy = GameObject.Find("EnemySpawn").transform.Find("Enemy").gameObject;
        eventCheck = GameObject.Find("EventPosition");
        gameManager = GameObject.Find("GameManager");
        cautionText = GameObject.Find("Canvas").transform.Find("caution").gameObject;
    }

    private void Update()
    {
        if (isSpawnBoss)
        {
            
            isDisableEasterEgg = enemy.GetComponent<enemyCtrl>().SpawnCheck();

            if (time < 5.0f)
            {
                cautionText.SetActive(true);
                time += Time.deltaTime;
                gameManager.GetComponent<CameraSetting>().changeToCamBoss();
            }
            else
            {
                cautionText.SetActive(false);
                gameManager.GetComponent<CameraSetting>().changeToCam();
            }
                
        }

        if (isDisableEasterEgg)
        {
            easterEgg.SetActive(false);
        }

    }

    //보스 이벤트 위치에서 트리거 발동
    private void OnTriggerEnter(Collider other)
    {
        if (isDisableEasterEgg) return;
        if (other.name != "unito") return;


        isSpawnEasterEgg = eventCheck.GetComponent<EventController>().isEventEasterEgg();
        if (!isSpawnEasterEgg) return;

        //보스 및 플래그 활성화
        enemy.SetActive(true);
        isSpawnBoss = true;

    }

    public bool isEventBoss()
    {
        return isSpawnBoss;
    }
}
