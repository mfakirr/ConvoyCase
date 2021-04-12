using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCarMovement : MonoBehaviour
{
    public float speed = 0;

    public bool canMove = true;

    private void FixedUpdate()
    {
        if (canMove)
        {
            transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        }
    }
}
