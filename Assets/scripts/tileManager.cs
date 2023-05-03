using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private Transform playerTransform;
    private float spwanZ=-3f;
    private float tileLength=12.2f;
    private float safeZone=10.0f;
    private int amnTileOnScreen=7;
    private List<GameObject> activeTiles;
    private int lastPrefabIndex=0;
    // Start is called before the first frame update
    void Start()
    {
        activeTiles=new List<GameObject>();
        playerTransform=GameObject.FindGameObjectWithTag("Player").transform;

        for (int i=0;i<amnTileOnScreen;i++)
        {
            if(i<2)
            {
                SpawnTile(0);
            }else
            {
                SpawnTile ();
            }
            
            
        }

        
       
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z-safeZone> (spwanZ-amnTileOnScreen*tileLength))
        {
            SpawnTile();
            DeleteTile ();
        }
       
    }

     void SpawnTile(int prefabIndex=-1)
        {
            GameObject go;
            if (prefabIndex == -1)
            {
                go=Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
            } else
            {
                go=Instantiate(tilePrefabs[prefabIndex]) as GameObject;
            }
            go.transform.SetParent(transform);
            go.transform.position=Vector3.forward* spwanZ;
            spwanZ+=tileLength;
            activeTiles.Add(go);
        }
        void DeleteTile()
        {
            Destroy(activeTiles[0]);
            activeTiles.RemoveAt(0);
        }

        private int RandomPrefabIndex()
        {
            if (tilePrefabs.Length <=1){
                return 0;
            }
            int randomIndex=lastPrefabIndex;
            while (randomIndex==lastPrefabIndex)
            {
                randomIndex=Random.Range(0, tilePrefabs.Length);
            }
            lastPrefabIndex=randomIndex;
            return randomIndex;
            
        }
    
    
}
