using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SpellboundForest.Enums;

public class InGameMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void BackToMainMenu()
    {
        Application.Quit();
    }
}
