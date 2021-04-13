using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{//is compenent with child of convoy
    PoolAbleObject poolAbleObject;

    [HideInInspector]
    public bool spawnCar=true;

    float[] xSpawnPositions = new float[6];
    
    public float spawnCarSpeed = 0;

    [SerializeField]
    GameObject[] cars;//I will give manually

    int carDirectionCheck = 0;

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

    int CheckForSameDirections(int point)
    {
        while (point == carDirectionCheck)
        {
            point = Random.Range(0, xSpawnPositions.Length);
        }
        return point;
    }

    void Start()
    {
        poolAbleObject = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PoolAbleObject>();

        #region xSpawnPoints
        //did it manually for spawner points
        xSpawnPositions[0] = 6.4f;
        xSpawnPositions[1] = 4.7f;
        xSpawnPositions[2] = 3.2f;
        xSpawnPositions[3] = 1.5f;
        xSpawnPositions[4] = 0;
        xSpawnPositions[5] = -1.6f;
        #endregion
        
        for (int i = 0; i < cars.Length; i++)
        {
            GameObject car = Instantiate(cars[i], spawnPoint, Quaternion.LookRotation(Vector3.back));

            poolAbleObject.AddCarTheList(car);

            car.SetActive(false);

            SpawnCarConfigure(car);
        }

        StartCoroutine(CarWave());
    }

    void ChooseRandomsCarAndPos()
    {
        carWillCreate              = cars[Random.Range(0, cars.Length)];

        int whereSpawnPoint        = Random.Range(0, xSpawnPositions.Length);
        int randomDistanceCarPoint = Random.Range(distanceSpawnCarMax, distanceSpawnCarMin);

        whereSpawnPoint =  CheckForSameDirections(whereSpawnPoint);

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
        GameObject car = null;
        if (poolAbleObject.HaveCars())
        {
            car = poolAbleObject.ListRandomCar();
            print("list");
            car.transform.position = spawnPoint;
        }
        else
        {
            car = Instantiate(carWillCreate, spawnPoint, Quaternion.LookRotation(Vector3.back));

            SpawnCarConfigure(car);
        }

    }

    void SpawnCarConfigure(GameObject car)
    {
        car.AddComponent<PoolSpawnCar>();

        car.AddComponent<SpawnCarMovement>();

        car.GetComponent<SpawnCarMovement>().speed = spawnCarSpeed;

        int random = Random.Range(0, 2);
        if (random == 1)
        {
            car.AddComponent<DropBomb>();
        }
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
