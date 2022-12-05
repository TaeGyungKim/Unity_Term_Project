using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEvent : MonoBehaviour
{
    private bool isSpawnEasterEgg;
    private bool isSpawnBoss;
    public GameObject easterEgg;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        //easterEgg 이벤트 발생 (360,0,0)
        easterEgg = GetComponent<GameObject>();
        //(400,0,130) 자리에서 보스전 시작
        enemy = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "unito") return;

        if (!isSpawnEasterEgg)
        {
            easterEgg.SetActive(true);
            isSpawnEasterEgg = true;
        }

        if (isSpawnBoss)
        {

        }
    }

    public bool isEventBoss()
    {
        return isSpawnBoss;
    }
}
