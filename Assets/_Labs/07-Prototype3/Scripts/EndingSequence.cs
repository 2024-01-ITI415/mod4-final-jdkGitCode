using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class EndingSequence : MonoBehaviour
{
    public GameObject[] endingPyramids = new GameObject[8];
    private int activePyramidCount;
    private bool gameEnded;

    public GameObject glassBreakParticles;
    public GameObject tinyBox;
    public GameObject bigBox;

    public AudioClip endingAudioClip;
    public AudioSource audioSource;
    public AudioSource backgroundMusic;

    public GameObject insufficentPyramidsTxt;
    public GameObject EndingTxt;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var pyramid in endingPyramids)
        {
            pyramid.SetActive(false);
        }

        glassBreakParticles.SetActive(false);
        EndingTxt.SetActive(false);
        insufficentPyramidsTxt.SetActive(false);

        activePyramidCount = 0;
    }

    void StartEnding()
    {
        gameEnded = true;
        SetNextPyramidActive();
        audioSource.Play(0);
        backgroundMusic.Pause();
    }

    void SetNextPyramidActive()
    {
        endingPyramids[activePyramidCount].SetActive(true);
        activePyramidCount++;

        if (activePyramidCount == 8)
        {
            Invoke(nameof(FinishEnding), 1);
        }
        else if (activePyramidCount == 6)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(endingAudioClip);
            Invoke(nameof(SetNextPyramidActive), 1);
        }
        else Invoke(nameof(SetNextPyramidActive), 1);
    }

    void FinishEnding()
    {
        glassBreakParticles.SetActive(true);
        foreach (var pyramid in endingPyramids)
        {
            pyramid.SetActive(false);
        }
        tinyBox.SetActive(false);
        bigBox.SetActive(false);

        Invoke(nameof(EndingText), 1f);
    }

    void EndingText()
    {
        EndingTxt.SetActive(true);
        backgroundMusic.UnPause();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (CollectableTracker.collectableTrackerSingleton.pyramidCount == 8 && !gameEnded)
                StartEnding();
            else if (gameEnded)
            {
                return;
            }
            else
            {
                insufficentPyramidsTxt.SetActive(true);
                insufficentPyramidsTxt.GetComponent<Text>().text = "You require " + (8 - CollectableTracker.collectableTrackerSingleton.pyramidCount) + " more power pyramids to unseal the desert";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insufficentPyramidsTxt.SetActive(false);
        }
    }
}
