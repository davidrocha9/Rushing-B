using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class SaveScoreManager : MonoBehaviour
{
    private SaveScoreData sd;

    void Awake()
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        sd = JsonUtility.FromJson<SaveScoreData>(json);
    }

    public IEnumerable<SaveScore> GetHighScores()
    {
        return sd.scores.OrderByDescending(x => x.score);
    }

    public void AddScore(SaveScore score)
    {
        sd.scores.Add(score);
        SaveScore();
    }

    private void OnDestroy()
    {
        //SaveScore();
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(sd);
        Debug.Log(json);
        PlayerPrefs.SetString("scores", json);
    }
}