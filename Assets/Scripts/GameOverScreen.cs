using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI coinsAlive, coinsGameOver, finalCoins;
    public TextMeshProUGUI metersAlive, metersGameOver, finalMeters;
    public TextMeshProUGUI notebooksAlive, notebooksGameOver, finalNotebooks;
    public GameObject score;
    public AudioClip gameMusic;
    public AudioManager audioManager;
    
    public void Setup() {
        gameObject.SetActive(true);
        audioManager.ChangeBackgroundMusic(gameMusic);

        coinsGameOver.text = System.Int32.Parse(coinsAlive.text).ToString();
        metersGameOver.text = System.Int32.Parse(metersAlive.text).ToString();
        notebooksGameOver.text = System.Int32.Parse(notebooksAlive.text).ToString();

        finalCoins.text = (System.Int32.Parse(coinsAlive.text) * 2).ToString();
        finalMeters.text = System.Int32.Parse(metersAlive.text).ToString();
        finalNotebooks.text = (System.Int32.Parse(notebooksAlive.text) * 100).ToString();

        finalScore.text = getFinalScore().ToString();

        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coins");
        GameObject[] lightbulbs = GameObject.FindGameObjectsWithTag("LightBulb");
        GameObject[] invLightbulbs = GameObject.FindGameObjectsWithTag("LightBulbInverted");
        GameObject[] trashcans = GameObject.FindGameObjectsWithTag("TrashCan");

        foreach (GameObject coin in coins) {
            Coin c = coin.GetComponent<Coin>();
        }

        foreach (GameObject lightbulb in lightbulbs) {
            LightBulb l = lightbulb.GetComponent<LightBulb>();
            l.bc.enabled = false;
        }

        foreach (GameObject invLightbulb in invLightbulbs) {
            LightBulbInverted il = invLightbulb.GetComponent<LightBulbInverted>();
            il.bc.enabled = false;
        }

        foreach (GameObject trashcan in trashcans) {
            TrashCan t = trashcan.GetComponent<TrashCan>();
        }
    }

    public void Update()
    {
        var col = score.GetComponent<CanvasGroup>();
        col.alpha -= 0.01f;
    }

    public int getFinalScore()
    {
        int metersScore = (System.Int32.Parse(metersAlive.text) * 1);
        int coinsScore = (System.Int32.Parse(coinsAlive.text) * 2);
        int notebooksScore = (System.Int32.Parse(notebooksAlive.text) * 100);

        return metersScore + coinsScore + notebooksScore;
    }

    public string buildFinalScoreText(int points) 
    {
        return metersGameOver.text + "*1 + " + coinsGameOver.text + "*2 + " + notebooksGameOver.text + "*100 = " + points.ToString();
    }
}
