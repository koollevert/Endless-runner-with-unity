using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public float turnSpeed = 90f;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name != "player") 
        {
            return;
        }
        CoinScoreScript.inst.IncreamentScore();

        Destroy(gameObject);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0, turnSpeed *Time.deltaTime);
        
    }

    
}

