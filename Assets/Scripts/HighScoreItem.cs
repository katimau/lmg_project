using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScoreItem
{
    public int score;
    public string name;

    public HighScoreItem(int score, string name)
    {
        this.score = score;
        this.name = name;
    }
}
