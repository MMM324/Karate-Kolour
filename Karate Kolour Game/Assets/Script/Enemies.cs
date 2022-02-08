using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    public Vector2 playerpos;
    public float speed = 3f;
    public int enemy_ID;
    public SpriteRenderer cube;

    void Start()
    {
        enemy_ID = Random.Range(0, 4);
        speed = Random.Range(3f, 6f);
        player = GameObject.FindGameObjectWithTag("player");
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        posture_check();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Deflected by" + other.name);

        if (other.tag == "player")
        {
            player_char karateka = other.GetComponent<player_char>();

            if (karateka != null)
            {
                if (karateka.posture_ID == enemy_ID)
                {
                    Destroy(this.gameObject);
                    karateka.score = karateka.score + 1;
                }
                else if (karateka.posture_ID != enemy_ID)
                {
                    karateka.ded();
                }
            }
        }
    }

    public void posture_check()
    {
        if (enemy_ID == 0)
        {
            cube.color = new Color(1, 0.5f, 0);
        }
        else if (enemy_ID == 1)
        {
            cube.color = new Color(0, 1, 0);
        }
        else if (enemy_ID == 2)
        {
            cube.color = new Color(1, 0, 1);
        }
        else if (enemy_ID == 3)
        {
            cube.color = new Color(1, 1, 0);
        }
    }
}
