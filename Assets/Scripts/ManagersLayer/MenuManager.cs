using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; set; }

    public MonoBehaviour cameraController; // Asigna el script de la cámara desde el editor
    public PlayerController playerController;

    public GameObject menuCanvas;
    //public GameObject uiCanvas; // no se si esto se necesita
    public bool isMenuOpen;

    public GameObject settingsMenu;
    public GameObject menu;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else 
        {
            Instance = this;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && !isMenuOpen)
        {
            //uiCanvas.SetActive(false);
            menuCanvas.SetActive(true);

            isMenuOpen = true;
            
            Cursor.lockState = CursorLockMode.None; // para permitir seleccionar con el ratón
            Cursor.visible = true;
            cameraController.enabled = false;
            playerController.allowInput = false; // Desactivar el control del jugador

        }
        else if (Input.GetKeyDown(KeyCode.M) && isMenuOpen) 
        {
            settingsMenu.SetActive(false);
            menu.SetActive(true);

            //uiCanvas.SetActive(true);
            menuCanvas.SetActive(false);

            isMenuOpen = false;

            Cursor.lockState = CursorLockMode.Locked; 
            Cursor.visible = false;
            cameraController.enabled = true;
            playerController.allowInput = true; // Desactivar el control del jugador
        }
    }
}
