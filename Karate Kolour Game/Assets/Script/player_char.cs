using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_char : MonoBehaviour
{
    public int posture_ID;
    public SpriteRenderer cube;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posture_check();
    }

    public void posture_check()
    {
        if (posture_ID == 0)
        {
            cube.color = new Color(2, 1, 0);
        }
        else if (posture_ID == 1)
        {
            cube.color = new Color(0, 1, 0);
        }
        else if (posture_ID == 2)
        {
            cube.color = new Color(1, 0, 1);
        }
        else if (posture_ID == 3)
        {
            cube.color = new Color(0, 0, 1);
        }
    }

    public void ded()
    {
        SceneManager.LoadScene("game_over");
    }

}
