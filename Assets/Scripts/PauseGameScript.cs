using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameScript : MonoBehaviour
{
    public static bool gamePaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gamePaused)
        {
            gamePaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gamePaused)
        {
            gamePaused = false;
        }
        if(gamePaused)
        {
            Time.timeScale = 0.05f;
        }
        else    Time.timeScale = 1;
    }
}
