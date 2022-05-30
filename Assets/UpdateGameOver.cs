using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string endType = PlayerPrefs.GetString("endType");
        GetComponent<Text>().text = endType == "death" ? "You were sent back by the spirits!" : "You completed the training!" ;
    }
}
