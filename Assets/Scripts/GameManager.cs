using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform unito;
    public GameObject rotatePosition;
    private float mapRotateMax = -90.0f;
    private float mapRoateSmooth = 5.0f;
    private bool mapRotateTriger = false;

    /*
    private bool isSpawnEasterEgg = false;
    private bool isSpawnBoss = false;
    public GameObject easterEgg;
    public GameObject enemy;*/

    // Start is called before the first frame update
    void Start()
    {
        //easterEgg 이벤트 발생 (360,0,0)
        //easterEgg = GetComponent<GameObject>();

        //(400,0,130) 자리에서 보스전 시작
        //enemy = GetComponent<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = unito.transform.position;

        mapRotateTriger = rotatePosition.GetComponent<mapRotate>().RotateCheck();

        float mapRotation = 0;

        if (mapRotateTriger)
            mapRotation = mapRotateMax;
        else
            mapRotation = 0;

        var target = Quaternion.Euler(new Vector3(0, mapRotation, 0));
        transform.rotation =
                Quaternion.Slerp(transform.rotation, target, Time.deltaTime * mapRoateSmooth);


    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "EventPosition")
        {
            if (!isSpawnEasterEgg)
            {
                easterEgg.SetActive(true);
                isSpawnEasterEgg = true;
            }

            if (isSpawnBoss)
            {

            }
        }



        if (other.name == "BossEventPosition" && isSpawnEasterEgg)
        {
            enemy.SetActive(true);
            isSpawnBoss = true;
        }
    }*/


}
