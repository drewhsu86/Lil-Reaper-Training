using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelToggler : MonoBehaviour
{
    [SerializeField] GameObject[] panelList;
    private Dictionary<string, int> panelMap = new Dictionary<string, int>() {
        {"instructions", 0},
        {"credits", 1}
    };

    public void QuitGame() {
        Application.Quit();
    }

    public void StartGame() {
        SceneManager.LoadScene("Level 1");
    }

    public void ToggleByIndex(int ind) {
        for (int i = 0; i < panelList.Length; i++) {
            panelList[i].SetActive(false);
        }
        panelList[ind].SetActive(true);
    }

    public void ToggleByName(string panelName) {
        if (panelMap[panelName] != null) ToggleByIndex(panelMap[panelName]);
    }
}
