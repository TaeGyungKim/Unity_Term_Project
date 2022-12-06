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

    // Start is called before the first frame update
    void Start()
    {
        unito = GameObject.Find("unito");
    }

    // Update is called once per frame
    void Update()
    {
         //if (unito.transform.position != null)
            this.transform.position = unito.transform.position;

        if (unito.GetComponent<playerController>().isDie())
        {
            
             time += Time.deltaTime;
            if (time > 2.0f) unito.SetActive(false);
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


    }
    private void OnGUI()
    {

    }
}
