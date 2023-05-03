using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    private bool isShowned;
    private float transition=0.0f;
    public TextMeshProUGUI scoreText;
    public Image backGroundImg;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isShowned)
        return;

        transition +=Time.deltaTime;
        backGroundImg.color=Color.Lerp(new Color (0, 0, 0, 0), Color.black, transition);
        
    }

    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive(true);
        scoreText.text=((int)score).ToString();
        isShowned=true;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
        /*SceneManager.LoadScene(SceneManager.GetActiveScene().name);*/

    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");

    }
}
    