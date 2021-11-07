using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScoreList
{
    public List<HighScoreItem> scores;

    public HighScoreList(List<HighScoreItem> scores)
    {
        this.scores = scores;
    }
}
