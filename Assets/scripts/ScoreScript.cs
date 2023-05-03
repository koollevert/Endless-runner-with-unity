using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class ScoreScript : MonoBehaviour
{
    private float Score= 0.0f;
    public TextMeshProUGUI scoreText;
    private int difficultyLevel=1;
    private int scoreToNextLevel=10;
    private int MaxDifficultyLevel=10;
    private bool isDead = false;
    public DeathMenu deathMenu;
    

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }
        if(Score>=scoreToNextLevel)
        {
            LevelUp();
        }
        Score+= Time.deltaTime*difficultyLevel;
        scoreText.text=((int)Score).ToString(); 
    }

    void LevelUp()
    {
        if(difficultyLevel==MaxDifficultyLevel)
        {
            return;
        }
        scoreToNextLevel*=2;
        difficultyLevel++;

        GetComponent<playerMove>().SetSpeed(difficultyLevel);
    }

    public void onDeath()
    {
        isDead=true;
        if(PlayerPrefs.GetFloat("Highscore")<Score)
            PlayerPrefs.SetFloat("Highscore", Score);
        deathMenu.ToggleEndMenu(Score);
 
    }
}
