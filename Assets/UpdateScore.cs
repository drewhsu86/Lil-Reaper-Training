using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int score = PlayerPrefs.GetInt("playerScore");
        GetComponent<Text>().text = "Your score: " + score + " !";
    }
}
