using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters;
using System;

[Serializable]
public class SaveScoreData
{
    public List<SaveScore> scores;

    public SaveScoreData()
    {
        this.scores = new List<SaveScore>();
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
