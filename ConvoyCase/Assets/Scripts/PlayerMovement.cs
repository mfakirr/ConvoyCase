using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float chancingX = 0;
    [SerializeField]
    float slideSensitivity = 50;
    [SerializeField]
    float XBoundryMax, XBoundryMin;

    private void Start()
    {
        Application.targetFrameRate = 60;

        chancingX = transform.position.x;
    }

    void Update()
    {
        chancingX = Mathf.Clamp(transform.position.x, XBoundryMin, XBoundryMax);
        if (Input.GetMouseButton(0))
        {
            chancingX = Input.GetAxis("Mouse X") * Time.fixedDeltaTime * slideSensitivity;

            transform.position = new Vector3(transform.position.x + chancingX,
                                             transform.position.y, 
                                             transform.position.z);
        }
        
    }
}
