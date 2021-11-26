using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreComparerDescending : IComparer<HighScoreItem>
{
    public int Compare(HighScoreItem a, HighScoreItem b)
    {
        return b.score.CompareTo(a.score);
    }
}
