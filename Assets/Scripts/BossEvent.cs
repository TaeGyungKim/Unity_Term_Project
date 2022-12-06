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
        //easterEgg �̺�Ʈ �߻� (360,0,0)
        easterEgg = GameObject.Find("EasterEggSpawn").transform.Find("EasterEgg").gameObject;
        //(400,0,130) �ڸ����� ������ ����
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

    //���� �̺�Ʈ ��ġ���� Ʈ���� �ߵ�
    private void OnTriggerEnter(Collider other)
    {
        if (isDisableEasterEgg) return;
        if (other.name != "unito") return;


        isSpawnEasterEgg = eventCheck.GetComponent<EventController>().isEventEasterEgg();
        if (!isSpawnEasterEgg) return;

        //���� �� �÷��� Ȱ��ȭ
        enemy.SetActive(true);
        isSpawnBoss = true;

    }

    public bool isEventBoss()
    {
        return isSpawnBoss;
    }
}
