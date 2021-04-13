using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimoCrush : MonoBehaviour
{
    GameManager gameManager;

    [HideInInspector]
    public int health = 2;

    [SerializeField]
    GameObject ExplosionParticleEffect = default;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider touch)
    {
        if (touch.CompareTag("EnemyCar") || touch.CompareTag("Bomb"))
        {
            Destroy(touch.gameObject);

            health--;

            gameManager.UIHealtControl(health);

            if (health == 0)
            {
                GameObject particle = Instantiate(ExplosionParticleEffect, transform.position, Quaternion.identity);
                Destroy(particle, 0.75f);
                
                Destroy(this.gameObject);

                gameManager.GameOver();               
            }
        }
    }
}
