using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{//is compenent with child of convoy
    [HideInInspector]
    public bool spawnCar=true;

    float[] xSpawnPositions = new float[6];
    
    public float spawnCarSpeed = 0;

    [SerializeField]
    GameObject[] cars;//I will give manually

    #region rondomResults
    Vector3 spawnPoint = Vector3.zero;

    GameObject carWillCreate = default;

    float timeBetweenCreate = 0;
    float timeBetweenWave = 0;
    #endregion 
    
    #region boundiriesRandoms
    [SerializeField]
    float timeBetweenCreateMax, timeBetweenCreateMin;

    [SerializeField]
    float timeBetweenWaveMax, timeBetweenWaveMin;

    [SerializeField]
    int distanceSpawnCarMax, distanceSpawnCarMin;

    int howManyCar = 0;
    #endregion

    void Start()
    {
        #region xSpawnPoints
        //did it manually for spawner points
        xSpawnPositions[0] = 6.4f;
        xSpawnPositions[1] = 4.7f;
        xSpawnPositions[2] = 3.2f;
        xSpawnPositions[3] = 1.5f;
        xSpawnPositions[4] = 0;
        xSpawnPositions[5] = -1.6f;
        #endregion

        StartCoroutine(CarWave());
    }

    void ChooseRandomsCarAndPos()
    {
        carWillCreate              = cars[Random.Range(0, cars.Length)];

        int whereSpawnPoint        = Random.Range(0, xSpawnPositions.Length);
        int randomDistanceCarPoint = Random.Range(distanceSpawnCarMax, distanceSpawnCarMin);

        spawnPoint = new Vector3(xSpawnPositions[whereSpawnPoint],
                                 transform.position.y,
                                 transform.position.z + randomDistanceCarPoint);

        timeBetweenWave = Random.Range(timeBetweenWaveMax, timeBetweenCreateMin);//time between create car
    }

    void ChooseRandomsTimeAndNumber()
    {
        howManyCar = Random.Range(1, 4);

        timeBetweenCreate = Random.Range(timeBetweenCreateMax, timeBetweenCreateMin);
    }

    void SpawnCarAndAddComponent()
    {
        GameObject car = Instantiate(carWillCreate, spawnPoint, Quaternion.LookRotation(Vector3.back));

        SpawnCarConfigure(car);
    }

    void SpawnCarConfigure(GameObject car)
    {
       car.AddComponent<SpawnCarMovement>();

       car.GetComponent<SpawnCarMovement>().speed = spawnCarSpeed;
    }

    IEnumerator CarWave()
    {
        while (spawnCar)
        {
            ChooseRandomsTimeAndNumber();
            for (int i = 0; i < howManyCar; i++)
            {
                ChooseRandomsCarAndPos();
                SpawnCarAndAddComponent();
                yield return new WaitForSeconds(timeBetweenWave);
            }
            yield return new WaitForSeconds(timeBetweenCreate);
        }
    }



}
