using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameScript : MonoBehaviour
{
    public static bool gameSlowed = false;
    public static bool gamePaused = false;

    private StressScript stressScript;
    public float slowedAnger;

    private void Start()
    {
        stressScript = FindAnyObjectByType<StressScript>();
    }
    void Update()
    {
        if (!gamePaused)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !gameSlowed)
            {

                gameSlowed = true;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && gameSlowed)
            {
                gameSlowed = false;
            }
            if (gameSlowed)
            {
                FindObjectOfType<UIScript>().FadeImage(true);
                stressScript.ChangeStressAmount(slowedAnger);
                Time.timeScale = 0.1f;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !gamePaused)
        {
            gamePaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gamePaused)
        {
            gamePaused = false;
        }
        if (gamePaused)
        {
            Time.timeScale = 0;
        }
        else if(!gamePaused && !gameSlowed || stressScript.currentStress >= stressScript.maxStress)
        {
            FindObjectOfType<UIScript>().FadeImage(false);
            Time.timeScale = 1;

        }

    }
}
