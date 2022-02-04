using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_manager : MonoBehaviour
{
    public GameObject Enemy_Prefab;
    public GameObject[] Spawners;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Instantiate(Enemy_Prefab, new Vector3(Random.Range(7f, -7f), Random.Range(3f, 7f), 0), Quaternion.identity);
            yield return new WaitForSeconds(4f);
        }
    }

}
