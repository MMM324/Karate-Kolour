using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_manager : MonoBehaviour
{
    public player_char points;
    public GameObject Enemy_Prefab;
    public GameObject[] Spawners;
    public bool isSpawningEnemies;
    public int[] cantEnemies;
    public int enemycounter;
    public int waiTime = 5;
    public enum actualEnemiesState
    {
        easy, normal, hard
    }
    public actualEnemiesState state;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    public void WaitTIme(actualEnemiesState state)
    {
        switch (state)
        {
            case actualEnemiesState.normal:
                waiTime = 3;
                break;
            case actualEnemiesState.hard:
                waiTime = 1;
                break;
            default:
                break;
        }
    }

    IEnumerator SpawnEnemies()
    {


        while (isSpawningEnemies)
        {

            for (int i = 0; i < cantEnemies[(int)state]; i++)
            {
                Instantiate(Enemy_Prefab, new Vector3(Random.Range(10f, -10f), Random.Range(8f, 15f), 0), Quaternion.identity);
                enemycounter++;
                if (points.score >= 5 && points.score <= 10) 
                {
                    state = actualEnemiesState.normal;
                }
                else if (points.score > 10) { state = actualEnemiesState.hard; }
                WaitTIme(state);
                yield return new WaitForSeconds(waiTime);
            }
        }


    }





}
