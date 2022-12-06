using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private GameObject unito;
    public GameObject rotatePosition;
    private float mapRotateMax = -90.0f;
    private float mapRoateSmooth = 5.0f;
    private bool mapRotateTriger = false;
    float time = 0.0f;
    /*
    private bool isSpawnEasterEgg = false;
    private bool isSpawnBoss = false;
    public GameObject easterEgg;
    public GameObject enemy;*/
    private GameObject eventController;

    private GameObject gameoverText;
    private GameObject clearText;

    private GameObject enemy;
    private GameObject enemyEvent;

    // Start is called before the first frame update
    void Start()
    {
        unito = GameObject.Find("unito");
        eventController = GameObject.Find("EventPosition");
        gameoverText = GameObject.Find("Canvas").transform.Find("gameover").gameObject;
        clearText = GameObject.Find("Canvas").transform.Find("clear").gameObject;

        enemy = GameObject.Find("EnemySpawn").transform.Find("Enemy").gameObject;
        enemyEvent = GameObject.Find("EnemySpawn").transform.Find("endEvent").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
         //if (unito.transform.position != null)
            this.transform.position = unito.transform.position;

        if (unito.GetComponent<playerController>().isDie())
        {
            gameoverText.SetActive(true);
            if (time < 2.0f)
             time += Time.deltaTime;
            else 
                unito.SetActive(false);

            if (Input.GetKeyDown(KeyCode.R))
                GetComponent<scene_transition>().sceneToStartTransition();


        }

        mapRotateTriger = rotatePosition.GetComponent<mapRotate>().RotateCheck();

        float mapRotation = 0;

        if (mapRotateTriger)
            mapRotation = mapRotateMax;
        else
            mapRotation = 0;

        var target = Quaternion.Euler(new Vector3(0, mapRotation, 0));
        transform.rotation =
                Quaternion.Slerp(transform.rotation, target, Time.deltaTime * mapRoateSmooth);

        //¿£µù
        if (eventController.GetComponent<EventController>().isEnd() 
            && this.transform.position.x < 200.0f)
        {
            enemyEvent.SetActive(true);
            enemyEvent.transform.position = enemy.transform.position;
            enemy.SetActive(false);
            
            clearText.SetActive(true);

            GetComponent<CameraSetting>().changeToCamEnd();

            if (Input.GetKeyDown(KeyCode.R))
                GetComponent<scene_transition>().sceneToStartTransition();
        }

    }
}
