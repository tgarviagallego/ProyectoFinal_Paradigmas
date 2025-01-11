using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuManager : MenuManagerBase
{
    private static GameMenuManager _instance;
    public static GameMenuManager Instance => _instance;

    [SerializeField] private MonoBehaviour cameraController;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject victoryMenu;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(menuCanvas);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowPauseMenu()
    {
        HideAllMenus();
        menuCanvas.SetActive(true);
        pauseMenu.gameObject.SetActive(true);
    }

    public void ShowVictoryMenu()
    {
        HideAllMenus();
        menuCanvas.SetActive(true);
        victoryMenu.gameObject.SetActive(true);
    }

    public override void HideAllMenus()
    {
        menuCanvas.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public override void EnableMenuControls()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (cameraController != null) cameraController.enabled = false;
        if (playerController != null) playerController.allowInput = false;
    }

    public override void EnableGameplayControls()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (cameraController != null) cameraController.enabled = true;
        if (playerController != null) playerController.allowInput = true;
    }
}
