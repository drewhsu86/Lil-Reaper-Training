using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int scoreCount = 0;
    [SerializeField] Text scoreText;

    void Start()
    {
        if (scoreText == null) scoreText = GameObject.FindWithTag("ScoreText").GetComponent<Text>();
    }

    public void AddToScore(int points = 1) {
        scoreCount += points;
        UpdateScoreUI(scoreCount);
    }

    private void UpdateScoreUI(int score) {
        scoreText.text = "Soul Power: " + score;
    }

    public int GetScore() {
        return scoreCount;
    }
}
