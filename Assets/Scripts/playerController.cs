using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    player_move player;

    private GameObject enemy;
    private GameObject bossCheck;
    float distance = 0.0f;
    bool isDied = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<player_move>();

        bossCheck = GameObject.Find("BossEventPosition");
        enemy = GameObject.Find("EnemySpawn").transform.Find("Enemy").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (bossCheck.GetComponent<BossEvent>().isEventBoss() && !isDied)
        {
            distance = enemy.GetComponent<enemyCtrl>().Distance();
            if (distance < 7.0f) {
                
                isDied = true;
                Die();
            }

        }
    }

    public void Die()
    {
        GetComponent<ParticleSystem>().Play();
        player.DisableMove();
    }

    public bool isDie()
    {
        return isDied;
    }


}
