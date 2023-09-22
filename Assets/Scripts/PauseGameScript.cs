using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameScript : MonoBehaviour
{
    public GameObject pasueMenu;
    public static bool gameSlowed = false;
    public static bool gamePaused = false;

    private StressScript stressScript;
    public float slowedAnger;

    public AudioSource slowTime;

    private void Start()
    {
        stressScript = FindAnyObjectByType<StressScript>();
    }
    void Update()
    {
        if (!BossEnemy.GameWon) 
        {
            if (!gamePaused)
            {
                if (Input.GetKeyDown(KeyCode.Space) && !gameSlowed)
                {
                    gameSlowed = true;
                    slowTime.Play();
                }
                else if (Input.GetKeyDown(KeyCode.Space) && gameSlowed)
                {
                    gameSlowed = false;
                    slowTime.Stop();
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
                pasueMenu.SetActive(true); 
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && gamePaused)
            {
                Resume();
            }
            if (gamePaused)
            {
                Time.timeScale = 0;
            }
            else if(!gamePaused && !gameSlowed || stressScript.currentStress >= stressScript.maxStress)
            {
                gamePaused = false;
                gameSlowed = false;
                FindObjectOfType<UIScript>().FadeImage(false);
                Time.timeScale = 1;
            }
        }
        else if(BossEnemy.GameWon)
        {
            gamePaused = false; 
            gameSlowed = false;
            pasueMenu.SetActive(false);
            Time.timeScale = 0;
        }
    }
    public void Resume()
    {
        gamePaused = false;
        pasueMenu.SetActive(false);
    }
}
