using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAnimator;
    public bool inProgress;

    public void SwitchDoorState()
    {

        if (!inProgress)
        {
            inProgress = true;

            if (!doorAnimator.GetBool("DoorState"))
            {
                doorAnimator.SetBool("DoorState", true);
            }
            else
            {
                doorAnimator.SetBool("DoorState", false);
            }
        }
    }

    public void AnimationDone()
    {
        inProgress = false;
    }
}
