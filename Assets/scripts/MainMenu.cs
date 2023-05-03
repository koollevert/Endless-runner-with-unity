using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; 
public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text="Highscore: "+ ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
        
    }


    public void ToGame()
    {
        SceneManager.LoadScene("Game");
    }
}
