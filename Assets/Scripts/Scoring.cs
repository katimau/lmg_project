using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Scoring : MonoBehaviour
{
    private Text scoreText;

    private int scoreBacking;
    public int Score
    {
        get => scoreBacking;
        set
        {
            scoreBacking = value;
            UpdateScoreText();
        }
    }

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    void UpdateScoreText()
    {
        scoreText.text = "SCORE:" + Score;
    }
}
