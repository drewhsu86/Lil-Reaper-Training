using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHighScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int score = PlayerPrefs.GetInt("playerScore");
        int highScore = PlayerPrefs.GetInt("highScore");
        if (highScore == null || score > highScore) {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
        }
        GetComponent<Text>().text = "High score: " + highScore + " !!!";
    }
}
