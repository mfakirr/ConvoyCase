using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSpawnCar : MonoBehaviour
{
    PoolAbleObject poolAbleObject;
    GameObject myGameobject;

    private void Start()
    {
        poolAbleObject = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PoolAbleObject>();

        myGameobject = gameObject;

        Invoke("PoolTheObject", 15);
    }

    void PoolTheObject()
    {
            poolAbleObject.AddCarTheList(this.gameObject);
    }

}
