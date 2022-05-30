using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public void GotoMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
