using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class UIReturnToMainMenu : MonoBehaviour
{
    public GameObject openingScreen;
    public GameObject returnMenu;

    public FirstPersonController playerController;
    public CharacterController characterController;


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
        playerController.enabled = !playerController.enabled;
        characterController.enabled = !characterController.enabled;
        Cursor.visible = false;
        returnMenu.SetActive(false);
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
            playerController.enabled = !playerController.enabled;
            characterController.enabled = !characterController.enabled;

            if (returnMenu.activeInHierarchy)
            {
                returnMenu.SetActive(false);
                Cursor.visible = false;
            }
            else
            {
                returnMenu.SetActive(true);
                Cursor.visible = true;
            }
        }
    }
}
