using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgescript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        spawnCoins();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public GameObject coinPrefab;

    void spawnCoins()
    {
        int coinsToSpawn=5;
        for(int i=0; i<coinsToSpawn; i++)
        {
            GameObject temp =Instantiate(coinPrefab, transform);
            temp.transform.position=GetRandomPointInCollider(GetComponent<Collider>());
        }


    }


    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point= new Vector3(
            Random.Range(collider.bounds.min.x,collider.bounds.max.x),
            Random.Range(collider.bounds.min.y,collider.bounds.max.y),
            Random.Range(collider.bounds.min.z,collider.bounds.max.z)
        );
        /*if(point != collider.ClosestPoint(point))
        {
            point=GetRandomPointInCollider(collider);
        }*/
        point.y=1;
        return point;

    }    
}
