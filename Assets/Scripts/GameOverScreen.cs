using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI coinsAlive, coinsGameOver;
    public TextMeshProUGUI metersAlive, metersGameOver; 
    public void Setup() {
        gameObject.SetActive(true);
        coinsGameOver.text = System.Int32.Parse(coinsAlive.text).ToString();
        metersGameOver.text = System.Int32.Parse(metersAlive.text).ToString();


        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coins");
        GameObject[] lightbulbs = GameObject.FindGameObjectsWithTag("LightBulb");
        GameObject[] trashcans = GameObject.FindGameObjectsWithTag("TrashCan");

        foreach (GameObject coin in coins) {
            Coin c = coin.GetComponent<Coin>();
        }

        foreach (GameObject lightbulb in lightbulbs) {
            LightBulb l = lightbulb.GetComponent<LightBulb>();
            l.bc.enabled = false;
        }

        foreach (GameObject trashcan in trashcans) {
            TrashCan t = trashcan.GetComponent<TrashCan>();
        }
    }
}