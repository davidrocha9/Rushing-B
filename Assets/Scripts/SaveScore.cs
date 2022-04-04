using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SaveScore
{
    public string playerName;
    public int score;

    public SaveScore(string playerName, int score)
    {
        this.playerName = playerName;
        this.score = score;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
