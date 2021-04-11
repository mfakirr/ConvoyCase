using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float chancingX = 0;
    [SerializeField]
    float slideSensitivity = 50;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            chancingX = Input.GetAxis("Mouse X") * Time.fixedDeltaTime * slideSensitivity;

            transform.position = new Vector3(transform.position.x + chancingX, transform.position.y, transform.position.z);
        }
        
    }
}
