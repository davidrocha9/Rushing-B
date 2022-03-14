using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;
    public TextMeshProUGUI text;
    public TextMeshProUGUI meters;
    int score = 0, currentMeters = 0, incrementMetersCounter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        incrementMetersCounter += 1;
        if (incrementMetersCounter > 10)
        {
            currentMeters += 1;
            meters.text = currentMeters.ToString().PadLeft(4, '0');
            incrementMetersCounter = 0;
        }
    }

    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = score.ToString().PadLeft(3, '0');
    }
}
