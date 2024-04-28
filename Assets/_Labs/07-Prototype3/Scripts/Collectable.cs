using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    public AnimationClip pickupAnimation;
    public Animator animator;
    public GameObject particles;

    private bool collected;

    private void Start()
    {
        particles.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !collected)
        {
            collected = true;
            audioSource.PlayOneShot(audioClip);

            animator.Play(pickupAnimation.name);
            particles.SetActive(true);
        }
    }

    public void FinishPickingUp()
    {
        particles.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
