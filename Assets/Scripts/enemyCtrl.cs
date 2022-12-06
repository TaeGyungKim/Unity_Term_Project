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

    //����, ����Ʈ
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
        
        //�÷��̾ �ٶ󺻴�
        //this.transform.LookAt(look.transform);
        
        //�ٴڿ� ��� �� �÷��̾�� �̵�
        if(spawnCheck)
        this.transform.position =
            Vector3.MoveTowards(this.transform.position, unito.position, speed * Time.deltaTime);

        //�÷��̾�� �浹 ��ġ���� �Ÿ� ����
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

        //�浹�� ��ƼŬ �߻� ��
        //�����Ҷ����� ����� && ���� ��ƼŬ, ���� ���
        GetComponent<ParticleSystem>().Play();

        AudioSource.PlayClipAtPoint(collision_sound, this.transform.position);
        //���������� �����Ѵ�.
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
