using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] int timerStart = 300; // in seconds
    int timerCount;
    float secondCount = 0;
    [SerializeField] Text timerText;
    Spawner spawner;

    void Start()
    {
        timerCount = timerStart;
        spawner = GetComponent<Spawner>();
    }

    void Update()
    {
        CheckSeconds();
        UpdateSeconds();
    }

    private void CheckSeconds() {
        secondCount += Time.deltaTime;
        if (secondCount >= 1.0f) {
            secondCount = 0;
            timerCount -= 1;
            HappensEverySecond();
        }
    }

    private void UpdateSeconds() {
        timerText.text = ConvertSeconds(timerCount);
    }

    private string ConvertSeconds(int sec) {
        // format X:XX
        int minutes = sec/60;
        int seconds = sec%60;
        return  minutes + ":" + (seconds <= 9 ? "0" : "") + seconds;
    }

    private void HappensEverySecond() {
        CheckTimeEnd();
        CheckSpawn();
    }

    private void CheckTimeEnd() {
        if (timerCount <= 0) {
            PlayerPrefs.SetString("endType", "timer");
            EndGame();
        }
    }

    public void EndGame() {
        int endScore = GetComponent<Score>().GetScore();
        PlayerPrefs.SetInt("playerScore", endScore);
        SceneManager.LoadScene("End");
    }

    private void CheckSpawn() {
        spawner.CheckEachSecond(timerStart - timerCount);
    }
}
