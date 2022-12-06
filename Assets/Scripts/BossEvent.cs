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

    // Start is called before the first frame update
    void Start()
    {
        //easterEgg 이벤트 발생 (360,0,0)
        easterEgg = GameObject.Find("EasterEggSpawn").transform.Find("EasterEgg").gameObject;
        //(400,0,130) 자리에서 보스전 시작
        enemy = GameObject.Find("EnemySpawn").transform.Find("Enemy").gameObject;
        eventCheck = GameObject.Find("EventPosition");
    }

    private void Update()
    {
        if (isSpawnBoss)
        {
            isDisableEasterEgg = enemy.GetComponent<enemyCtrl>().SpawnCheck();
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
