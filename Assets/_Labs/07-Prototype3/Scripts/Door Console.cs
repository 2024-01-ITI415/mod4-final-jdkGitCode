using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorConsole : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    public GameObject door;
    public GameObject onScreen;
    public bool consoleState;

    private void Start()
    {
        consoleState = false;
        onScreen.SetActive(false);
        
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
