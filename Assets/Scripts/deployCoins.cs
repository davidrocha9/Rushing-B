using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployCoins : MonoBehaviour
{
    public GameObject coinPrefab;
    public float respawnTime = 0.1f;
    private Vector2 screenBounds;

    // Use this for initialization
    void Start () {
        StartCoroutine(coinWave());
    }

    private void spawnCoin(){
        GameObject a = Instantiate(coinPrefab) as GameObject;
        a.transform.position = new Vector2(0, Random.Range(-10, 10));
    }

    IEnumerator coinWave(){
        while(true){
            yield return new WaitForSeconds(respawnTime);
            Debug.Log("goods");
            spawnCoin();
        }
    }
}
