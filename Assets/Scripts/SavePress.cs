using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SavePress : MonoBehaviour
{
    public TextMeshProUGUI score;
    public SaveScoreManager saveScoreManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void saveScore(string playerName)
    {
        saveScoreManager.AddScore(new SaveScore(playerName, System.Int32.Parse(score.text)));
    }
}
