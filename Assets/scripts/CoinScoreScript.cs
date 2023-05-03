using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CoinScoreScript : MonoBehaviour
{
    public int coinCollectScore;
    public TextMeshProUGUI coinScoreText;
    public static CoinScoreScript inst; //Instance of this class declaration
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    public void IncreamentScore()
    {
        coinCollectScore++;
        coinScoreText.text="Coins: "+coinCollectScore;

    }
    private void Awake()
    {
        inst=this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
