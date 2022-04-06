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
    int updateVal;
    CameraMovement cameraMovement;
    public float speed;
    public Deploy spawner;
    public int coffeeBoughtCnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        cameraMovement = GameObject.FindGameObjectsWithTag("CameraMovement")[0].GetComponent<CameraMovement>();
        speed = cameraMovement.speed;
    }

    void Update()
    {
    }

    void FixedUpdate()
    {        
        speed = cameraMovement.speed;
        incrementMetersCounter += 1 + speed/7.0f;
        
        if (GameObject.FindGameObjectsWithTag("Teacher").Length > 0)
            updateVal = 50;
        else
            updateVal = 10;

        if (incrementMetersCounter > updateVal)
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
        coinsCnt = System.Int32.Parse(coins.text) - (100 + 100 * coffeeBoughtCnt);
        coins.text = coinsCnt.ToString().PadLeft(3, '0');
        coffeeBoughtCnt++;
    }

    public void doorWarp()
    {
        currentMeters += 200;
        meters.text = currentMeters.ToString().PadLeft(4, '0');
        meters.color = new Color32(80, 80, 255, 255);
        
        float targetMeters = 0;
        float incrementMetersCounterAux = 0;
        while (targetMeters < 200)
        {
            speed += Time.deltaTime * 0.05f;
            incrementMetersCounterAux += 1 + speed/7.0f;
            updateVal = 10;

            if (incrementMetersCounterAux > updateVal)
            {
                targetMeters += 1;
                incrementMetersCounterAux = 0;
            }
        }

        cameraMovement.speed = speed;
    }

    public void animateMeters()
    {
        meters.color = new Color32(255, 255, 255, 255);
    }
}
