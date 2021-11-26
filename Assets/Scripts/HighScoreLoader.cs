using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreLoader : MonoBehaviour
{
    public GameObject highScoreTemplate;
    void OnEnable()
    {
        Debug.Log("High Score List Enabled");
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        List<HighScoreItem> scores = HighScoreManager.LoadScores();
        scores.Sort(new HighScoreComparerDescending());
        if (scores.Count > 10)
        {
            scores = scores.GetRange(0, 10);
        }

        foreach (HighScoreItem item in scores)
        {
            Debug.Log($"Adding {item.name}: {item.score}");
            GameObject hs = Instantiate(highScoreTemplate, transform);
            hs.transform.GetChild(0).GetComponent<Text>().text = item.score.ToString();
            hs.transform.GetChild(1).GetComponent<Text>().text = item.name;
            hs.SetActive(true);
        }
    }
}
