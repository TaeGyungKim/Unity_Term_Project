using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private GameObject enemy;
    private GameObject eventPosition;
    private bool isSpawnBoss = false;
    float distance = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<GameObject>();
        eventPosition = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        isSpawnBoss = eventPosition.GetComponent<EventController>().isEventBoss();

    }



}
