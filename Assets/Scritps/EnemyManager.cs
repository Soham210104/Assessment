using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] Transform enemySpawn_01,enemySpawn_02;
    public GameObject BOT01,BOT02;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy(BOT01,enemySpawn_01.position);
        SpawnEnemy(BOT02, enemySpawn_02.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy(GameObject BOT,Vector3 pos)
    {
        Instantiate(BOT, pos, Quaternion.identity);
    }

}
