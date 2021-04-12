using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float changingX = 0;
    [SerializeField]
    float slideSensitivity = 50;
    [SerializeField]
    float XBoundryMax, XBoundryMin;

    private void Start()
    {
        Application.targetFrameRate = 30;

        changingX = transform.position.x;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            changingX += Input.GetAxis("Mouse X") * Time.fixedDeltaTime * slideSensitivity;

            changingX = Mathf.Clamp(changingX, XBoundryMin, XBoundryMax);

            transform.position = new Vector3( changingX,
                                              transform.position.y, 
                                              transform.position.z);
        }
        
    }
}
