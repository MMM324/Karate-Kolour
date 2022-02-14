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
        //SetSpedd();
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
        switch (enemy_ID)
        {
            case 0:
                cube.color = new Color(1, 0.5f, 0);
                break;
            case 1:
                cube.color = new Color(0, 1, 0);
                break;
            case 2:
                cube.color = new Color(1, 0, 1);
                break;
            case 3:
                cube.color = new Color(1, 1, 0);
                break;
            default:
                break;
        }
    }
  /*public void SetSpedd() 
    {
    //No estaria reconociendo al karateka por lo que no se ejecuta la funcion
        if (karateka != null)
        {
            player_char karateka = gameObject.GetComponent<player_char>();
            if (karateka.score >= 5 && karateka.score <= 10)
            {
                speed = Random.Range(7f, 10f);
            }
            else if (karateka.score > 10) { speed = Random.Range(7f, 10f); }
        }
        else { Debug.Log("No funca");  }
    }*/
}
