using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    public float speed = 3f;
    public int enemy_ID;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
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
                }
                else if (karateka.posture_ID != enemy_ID)
                {
                    karateka.ded();
                }
            }
        }
    }
}
