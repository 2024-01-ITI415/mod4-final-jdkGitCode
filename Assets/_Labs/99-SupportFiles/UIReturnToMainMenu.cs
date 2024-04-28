using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class UIReturnToMainMenu : MonoBehaviour
{
    public GameObject openingScreen;
    public GameObject returnMenu;
    public GameObject endingTxt;
    public GameObject insufficentPyramidsTxt;
    public FirstPersonController playerController;

    public void Awake()
    {
        returnMenu.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ReactivateOpening()
    {
        openingScreen.SetActive(true);
    }

    public void CloseReturnMenu()
    {
        returnMenu.SetActive(false);
        playerController.m_MouseLook.inMenu = false;
    }

    public void CloseTextPopups()
    {
        openingScreen.SetActive(false);
        endingTxt.SetActive(false);
        insufficentPyramidsTxt.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Mouse0)))
        {
            CloseTextPopups();
        }
        if ((Input.GetKeyDown(KeyCode.Escape)))
        {
            CloseTextPopups();
            if (returnMenu.activeInHierarchy)
            {
                returnMenu.SetActive(false);
                playerController.m_MouseLook.inMenu = false;
            }
            else
            {
                returnMenu.SetActive(true);
                playerController.m_MouseLook.inMenu = true;
            }
        }
    }
}
