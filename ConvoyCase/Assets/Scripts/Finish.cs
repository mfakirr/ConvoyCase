using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField]
    float distance = 0;

    [SerializeField]
    GameObject carSpawner;

    private void LateUpdate()
    {
       distance = Vector3.Distance(transform.position, Vector3.zero);
        if (distance > 30)
        {
            carSpawner.SetActive(false);
        }
        if (distance > 40)
        {
            Time.timeScale = 0;
            print("win");
        }
    }
}
