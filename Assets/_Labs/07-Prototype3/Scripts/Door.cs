using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAnimator;
    public bool doorState;

    public void SwitchDoorState()
    {
        Debug.Log(doorAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);

        if (doorAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0)
        {
            if (!doorState)
            {
                doorState = !doorState;
                doorAnimator.Play("OpenDoor");
            }
            else
            {
                doorState = !doorState;
                doorAnimator.Play("CloseDoor");
            }
        }
    }
}
