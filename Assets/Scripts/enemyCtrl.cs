// Start is called before the first frame update
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCtrl : MonoBehaviour
{
    //
    private bool isSpawnEasterEgg;
    private bool isJump= false;
    private bool spawnCheck = false;
    public float speed = 13.0f;
    public float jumpPower = 70000.0f;

    float distance = 0f;
    public Transform unito;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //�÷��̾ �ٶ󺻴�
        //this.transform.LookAt(unito);
        this.transform.position =
            Vector3.MoveTowards(this.transform.position, unito.position, speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        spawnCheck = true;
        //�浹�� ��ƼŬ �߻� �� 
        // �÷��̾�� �Ÿ� ����
        GetComponent<ParticleSystem>().Play();

        Vector3 collided_position = transform.position;

        //������� �浹 ��ġ���� �Ÿ� ����
        distance = (collided_position.x - unito.position.x) * (collided_position.x - unito.position.x) +
            (collided_position.y - unito.position.y) * (collided_position.y - unito.position.y);

        distance = Mathf.Sqrt(distance);
        //Debug.Log(collided_position);
       // Debug.Log(distance);

 
            rigidbody.AddForce(0, jumpPower, 0);
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
