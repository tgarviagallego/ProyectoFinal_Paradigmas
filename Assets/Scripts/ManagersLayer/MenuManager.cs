using SpellboundForest.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; set; }

    [SerializeField] private MonoBehaviour cameraController; // Asigna el script de la cámara desde el editor
    [SerializeField] private PlayerController playerController;

    [SerializeField] private GameObject menuCanvas;
    //public GameObject uiCanvas; // no se si esto se necesita

    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject menu;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(menuCanvas);
    }

    public void ShowPauseMenu()
    {
        HideAllMenus();
        menuCanvas.SetActive(true);
        menu.SetActive(true);
    }

    public void HideAllMenus()
    {
        menuCanvas.SetActive(false);
        menu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void EnableMenuControls()
    {
        Cursor.lockState = CursorLockMode.None; // para permitir seleccionar con el ratón
        Cursor.visible = true;
        if (cameraController != null) cameraController.enabled = false;
        if (playerController != null) playerController.allowInput = false; // Desactivar el control del jugador
    }

    public void EnableGameplayControls()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (cameraController != null) cameraController.enabled = true;
        if (playerController != null) playerController.allowInput = true; // Desactivar el control del jugador
    }
}
