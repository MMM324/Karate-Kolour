using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_manager : MonoBehaviour
{
    public GameObject Enemy_Prefab;
    public GameObject[] Spawners;
    public bool isSpawningEnemies;
    public int[] cantEnemies;
    public int enemycounter;
    public enum actualEnemiesState
    {
        easy, normal, hard
    }
    public actualEnemiesState state;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {


        while (isSpawningEnemies)
        {

            for (int i = 0; i < cantEnemies[(int)state]; i++)
            {
                Instantiate(Enemy_Prefab, new Vector3(Random.Range(10f, -10f), Random.Range(8f, 15f), 0), Quaternion.identity);
                enemycounter++;
            }
            yield return new WaitForSeconds(4f);
        }


    }




}
