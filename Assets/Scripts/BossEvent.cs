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
        //easterEgg �̺�Ʈ �߻� (360,0,0)
        easterEgg = GetComponent<GameObject>();
        //(400,0,130) �ڸ����� ������ ����
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
