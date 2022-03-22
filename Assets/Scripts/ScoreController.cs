using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;
    public TextMeshProUGUI meters;
    public TextMeshProUGUI coins;
    public TextMeshProUGUI notebooks;
    int coinsCnt = 0, notebooksCnt = 0, currentMeters = 0, incrementMetersCounter = 0;
    
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

    public void increaseCoins()
    {
        coinsCnt += 1;
        coins.text = coinsCnt.ToString().PadLeft(3, '0');
    }

    public void increaseNotebooks()
    {
        notebooksCnt += 1;
        notebooks.text = notebooksCnt.ToString().PadLeft(2, '0');
    }
}
