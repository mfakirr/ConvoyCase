using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampRoadCheck : MonoBehaviour
{
    int limoXPosition = 4;//check it manually
    int limoZPosition = 12;

    int myXPosition = 0;
    int myZPosition = 0;

    private void OnEnable()
    {
        myXPosition = Mathf.RoundToInt(transform.localPosition.x);
        myZPosition = Mathf.RoundToInt(transform.localPosition.z);
    }

    private void OnDestroy()
    {
        print("girdi");
        if (limoZPosition >= myZPosition)
        {
            print("zpos");
            if (limoXPosition < myXPosition)
            {
                print("xright");
                GetComponentInParent<PlayerMovement>().RightCheck();
            }
            else
            { 
                print("xleft");
                GetComponentInParent<PlayerMovement>().LeftCheck();
            }
        }   
    }
}
