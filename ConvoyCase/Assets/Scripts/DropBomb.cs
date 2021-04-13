using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
    GameObject bomb = default;

    public bool canGoPresident = true;

    Vector3 president = default;

    float step = 10;

    private void OnEnable()
    {
        bomb = GameObject.FindWithTag("Bomb");

        int random = Random.Range(0, 2);

        GetComponent<SpawnCarMovement>().enabled = true;

        if (random == 0)
        {
            Invoke("SuicideMisson", 1.5f);
        }
        else
        {
            Invoke("PlantBomb", 2.5f);
        }
    }

    void PlantBomb()
    {
        Instantiate(bomb, transform.position + (Vector3.up*0.5f) , Quaternion.identity);
    }

    void SuicideMisson()
    {
        president = GameObject.FindWithTag("Limo").transform.position;

        GetComponent<SpawnCarMovement>().enabled = false;

        StartCoroutine(Go());
    }

    IEnumerator Go()
    {
        while (canGoPresident)
        {
            transform.position = Vector3.MoveTowards(transform.position, president, step * Time.fixedDeltaTime);
            transform.LookAt(president);
            yield return null;
        }
    }
}
