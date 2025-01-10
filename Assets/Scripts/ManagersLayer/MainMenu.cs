using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void NewGame()
    {
        GameManager.Instance.StartGame();
    }

    // Update is called once per frame
    public void ExitGame()
    {
        Debug.Log("Quitting game");//to see that it is working
        Application.Quit(); // quit from game
    }
}
