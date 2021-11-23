using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnInfo
{
    public GameObject prefab;
    public float startTime;
    public float repeatIntervalMin;
    public float repeatIntervalMax;
    public float timeToNextSpawn;
    public Vector3 spawnPosition;
}
