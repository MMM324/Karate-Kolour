using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_char : MonoBehaviour
{
    public int posture_ID;
    public SpriteRenderer cube;
    public int score;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            
            if (rayHit)
            {
                if (rayHit.transform.tag == "posture_shift")
                {
                    posture_ID = rayHit.transform.GetComponent<Button>().button_ID;
                    

                }
            }
        }

        

        posture_check();
        inputsjaja();
    }

    public void posture_check()
    {
        if (posture_ID == 0)
        {
            cube.color = new Color(1, 0.5f, 0);
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
            cube.color = new Color(1, 1, 0);
        }
    }

    public void ded()
    {
        SceneManager.LoadScene("game_over");
    }

    public void inputsjaja()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            posture_ID = 0;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            posture_ID = 1;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            posture_ID = 2;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            posture_ID = 3;
        }
    }

}
