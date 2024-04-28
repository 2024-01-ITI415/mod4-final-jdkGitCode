using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityStandardAssets.Characters.FirstPerson;

public class UndergroundPassage : MonoBehaviour
{
    public GameObject interactibleText;
    public GameObject player;
    public Transform posToGoTo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactibleText.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.SetPositionAndRotation(posToGoTo.position, posToGoTo.rotation);
            player.GetComponent<CharacterController>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactibleText.SetActive(false);
        }
    }
}
