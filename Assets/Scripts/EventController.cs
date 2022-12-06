using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{

    private bool isSpawnEasterEgg;
    private bool isSpawnBoss;
    private bool isEnding;
    private GameObject easterEgg;
    private GameObject enemy;
    private GameObject eventCheck;

    // Start is called before the first frame update
    void Start()
    {
        //easterEgg �̺�Ʈ �߻� (360,0,0)
        easterEgg= GameObject.Find("EasterEggSpawn").transform.Find("EasterEgg").gameObject;

        //(400,0,130) �ڸ����� ������ ����
        enemy = GameObject.Find("EnemySpawn").transform.Find("Enemy").gameObject;

        //���� �̺�Ʈ �߻� Ȯ��
        eventCheck = GameObject.Find("BossEventPosition");
    }

    //�̺�Ʈ ��ġ���� Ʈ����
    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "unito") return; 

        //ù �̺�Ʈ �߻���
        if (!isSpawnEasterEgg)
        {
            easterEgg.SetActive(true);
            isSpawnEasterEgg = true;
        }
        //���� ���� �� ���� �̺�Ʈ
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
