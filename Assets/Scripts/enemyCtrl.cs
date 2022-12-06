// Start is called before the first frame update
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCtrl : MonoBehaviour
{
    //
    private bool spawnCheck = false;
    //private GameObject look;
    public float speed = 13.0f;
    public float jumpPower = 70000.0f;

    float distance = 10.0f;
    public Transform unito;
    private Rigidbody rigidbody;

    //사운드, 이펙트
    public AudioClip collision_sound;
    public Transform explosion_effect;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        //look = GameObject.Find("LookAt");
    }

    // Update is called once per frame
    void Update()
    {
        
        //플레이어를 바라본다
        //this.transform.LookAt(look.transform);
        
        //바닥에 충둘 후 플레이어로 이동
        if(spawnCheck)
        this.transform.position =
            Vector3.MoveTowards(this.transform.position, unito.position, speed * Time.deltaTime);

        //플레이어와 충돌 위치간에 거리 측정
        Vector3 collided_position = this.transform.position;

        distance = Mathf.Pow((collided_position.x - unito.position.x), 2) +
            Mathf.Pow((collided_position.z - unito.position.z), 2);
        distance = Mathf.Sqrt(distance);
        //Debug.Log(collided_position + "and" + unito.position);
        Debug.Log(distance);

    }

    private void OnCollisionEnter(Collision collision)
    {
        spawnCheck = true;

        //충돌시 파티클 발생 및
        //착지할때마다 충격파 && 폭발 파티클, 사운드 출력
        GetComponent<ParticleSystem>().Play();

        AudioSource.PlayClipAtPoint(collision_sound, this.transform.position);
        //지속적으로 점프한다.
        rigidbody.AddForce(0, jumpPower, 0);



        int num = Random.Range(1, 6);

        for (int i = 0; i<num; i++)
        {
            float x = Random.Range(-5f, 5f);
            float z = Random.Range(-5f, 5f);

            Vector3 randomPosition = new Vector3(transform.position.x + x, transform.position.y, transform.position.z +z);

            Instantiate(explosion_effect, randomPosition, this.transform.rotation);
        }

 
    }

    public float Distance()
    {
        return distance;
    }

    public bool SpawnCheck()
    {
        return spawnCheck;
    }

}
