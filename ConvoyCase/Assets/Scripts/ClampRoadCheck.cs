using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampRoadCheck : MonoBehaviour
{
    int limoXPosition = 4;//check it manually
    int limoZPosition = 12;

    int myXPosition = 0;
    int myZPosition = 0;

    PlayerMovement playerMovement;

    private void OnEnable()
    {
        myXPosition = Mathf.RoundToInt(transform.localPosition.x);
        myZPosition = Mathf.RoundToInt(transform.localPosition.z);

        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void OnDestroy()
    {
        if (limoZPosition >= myZPosition)
        {
            if (limoXPosition < myXPosition)
            {
                playerMovement.RightCheck();
            }
            else
            {
                playerMovement.LeftCheck();
            }
        }   
    }
}
