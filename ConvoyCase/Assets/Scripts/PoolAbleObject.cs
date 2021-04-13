using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolAbleObject : MonoBehaviour
{
    [SerializeField]
    List<GameObject> cars = new List<GameObject>();

    public void AddCarTheList(GameObject car)
    {
        car.SetActive(false);

        cars.Add(car);
    }

    public bool HaveCars()
    {
        if (cars.Count != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public GameObject ListRandomCar()
    {
            int randomCar = Random.Range(0, cars.Count);

            GameObject randomCarObj = cars[randomCar];

            randomCarObj.SetActive(true);

            cars.Remove(randomCarObj);
            
            return randomCarObj; 
    }

}
