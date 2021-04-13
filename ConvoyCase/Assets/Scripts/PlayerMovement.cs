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

    int leftSideCheck, rightSideCheck;

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
    #region BoundryChanges
    public void LeftCheck()
    {
        leftSideCheck += 1;
        if (leftSideCheck == 2)
        {
            XBoundryMin = -5.7f;
            //Check it manually in scene
        }
    }

    public void RightCheck()
    {
        rightSideCheck += 1;
        if (rightSideCheck == 2)
        {
            XBoundryMax = 2.7f;
        }
    }
    #endregion
}
