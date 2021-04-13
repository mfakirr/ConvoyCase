using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushController : MonoBehaviour
{
    [SerializeField]
    GameObject ExplosionParticleEffect = default;

    PoolAbleObject poolAbleObject;

    private void Start()
    {
        poolAbleObject = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PoolAbleObject>();
    }

    private void OnTriggerEnter(Collider Touch)
    {
        if (Touch.CompareTag("EnemyCar") || Touch.CompareTag("Bomb"))
        {
            GameObject particle = Instantiate(ExplosionParticleEffect, transform.position, Quaternion.identity);
            Destroy(particle, 0.75f);
            
            if (Touch.CompareTag("EnemyCar")) { poolAbleObject.AddCarTheList(Touch.gameObject); }

            Touch.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
