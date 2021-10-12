using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScoreItem
{
    public int score;
    public System.DateTime time;
    public string name;

    public HighScoreItem(int score, System.DateTime time, string name)
    {
        this.score = score;
        this.time = time;
        this.name = name;
    }
}
