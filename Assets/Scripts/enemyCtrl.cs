// Start is called before the first frame update
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCtrl : MonoBehaviour
{
    private bool isSpawnEasterEgg;
    private bool isJump= false;
    float distance = 0f;
    public Transform unito;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        unito = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.LookAt(unito);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<ParticleSystem>().Play();

        Vector3 collided_position = transform.position;


        distance = (collided_position.x - unito.position.x) * (collided_position.x - unito.position.x) +
            (collided_position.y - unito.position.y) * (collided_position.y - unito.position.y);

        distance = Mathf.Sqrt(distance);
        Debug.Log(collided_position);
        Debug.Log(distance);

        if (!isJump)
        {

        }
    }

    public float Distance()
    {
        return distance;
    }

   }
