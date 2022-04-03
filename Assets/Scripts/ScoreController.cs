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
    public GameObject pauseMenu;
    float coinsCnt = 0, notebooksCnt = 0, currentMeters = 0, incrementMetersCounter = 0;
    
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
    }

    void FixedUpdate()
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

    public void buyCoffee()
    {
        coinsCnt = Mathf.Round(0.50f * coinsCnt);
        coins.text = coinsCnt.ToString().PadLeft(3, '0');
    }

    public void doorWarp()
    {
        currentMeters += 200;
        meters.text = currentMeters.ToString().PadLeft(4, '0');
        meters.color = new Color32(80, 80, 255, 255);
        StartCoroutine(animateMeters());
    }

    public IEnumerator animateMeters()
    {
        yield return new WaitForSeconds(1);
        meters.color = new Color32(255, 255, 255, 255);
    }
}
