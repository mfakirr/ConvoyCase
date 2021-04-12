using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushController : MonoBehaviour
{
    [SerializeField]
    GameObject ExplosionParticleEffect = default;

    private void OnTriggerEnter(Collider Touch)
    {
        if (Touch.CompareTag("EnemyCar") || Touch.CompareTag("Bomb"))
        {
            GameObject particle = Instantiate(ExplosionParticleEffect, transform.position, Quaternion.identity);
            Destroy(particle, 0.75f);
            Destroy(Touch.gameObject);
            Destroy(this.gameObject);
        }
    }
}
