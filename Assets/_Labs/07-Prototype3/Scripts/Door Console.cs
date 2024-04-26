using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorConsole : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;

    public Door door;
    public GameObject consoleScreen;
    public GameObject interactibleText;

    private void Start()
    {
        consoleScreen.SetActive(false);
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(audioClip);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlaySound();
            consoleScreen.SetActive(true);
            interactibleText.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            door.SwitchDoorState();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            consoleScreen.SetActive(false);
            interactibleText.SetActive(false);
        }
    }
}
