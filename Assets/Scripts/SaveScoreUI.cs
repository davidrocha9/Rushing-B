using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SaveScoreUI : MonoBehaviour
{
    public RowUI rowUI;
    public SaveScoreManager saveScoreManager;

    // Start is called before the first frame update
    void Start()
    {        
        var scores = saveScoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            if (i == 5)
                break;
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.playerName.text = scores[i].playerName;
            row.score.text = scores[i].score.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
