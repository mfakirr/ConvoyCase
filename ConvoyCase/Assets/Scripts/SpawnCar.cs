using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    float[] xSpawnPositions = new float[6];

    [SerializeField]
    GameObject[] cars;//I will give manually

    [SerializeField]
    float timeBetweenCreateMax, timeBetweenCreateMin;
    [SerializeField]
    float timeBetweenWaveMax, timeBetweenWaveMin;
    [SerializeField]
    float distanceSpawnCar = 0;
    [SerializeField]
    int howManyCar = 0;

    void Start()
    {
        //did it manually for spawner points
        xSpawnPositions[0] = 6.4f;
        xSpawnPositions[1] = 4.7f;
        xSpawnPositions[2] = 3.2f;
        xSpawnPositions[3] = 1.5f;
        xSpawnPositions[4] = 0;
        xSpawnPositions[5] = -1.6f;
    }

    void Update()
    {
        
    }
}
