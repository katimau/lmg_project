using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //molemmat olivat privateja
    public GameObject obstaclePrefab;
    public GameObject itemPrefab;

    //vedä tähän SpawnManager Unityssa, korjaa spawnPos -tehty
    public GameObject spawnPoint;

    //molemmat olivat privateja
    public Vector3 spawnPosObject = new Vector3(35, 0, 0);
    public Vector3 spawnPosItem = new Vector3(45, 0, 0);

    //startDelay ja repeatRate olivat molemmat 2, mutta kokeillaan näin alkuun
    //molemmat olivat privateja
    public float startDelay = 5;
    public float repeatRate = 2;

    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        InvokeRepeating("SpawnItem", startDelay, repeatRate);
    }

    void Update()
    {

    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPosObject, obstaclePrefab.transform.rotation);
        }
    }

    void SpawnItem()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(itemPrefab, spawnPosItem, itemPrefab.transform.rotation);
        }
    }
}
