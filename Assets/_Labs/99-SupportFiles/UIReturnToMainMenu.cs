using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class UIReturnToMainMenu : MonoBehaviour
{
    public GameObject openingScreen;
    public GameObject returnMenu;
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

    // Update is called once per frame
    public void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Mouse0)))
        {
            openingScreen.SetActive(false);
        }
        if ((Input.GetKeyDown(KeyCode.Escape)))
        {
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
