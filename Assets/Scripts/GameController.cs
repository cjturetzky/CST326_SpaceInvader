using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int totalScore = 0;
    private static int highScore;
    public TextMeshProUGUI hiScoreText;
    string highScoreKey = "HighScore";
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey,0);
        hiScoreText.SetText("High Score\n{0:00000}", highScore);
        foreach (Enemy e in FindObjectsOfType<Enemy>()){
            e.deathEvent += onEnemyDeath;
        }
        FindObjectOfType<Player>().playerDeathEvent += onPlayerDeath;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onEnemyDeath(int score){
        Debug.Log("Kill confirmed!");
        totalScore += score;
        scoreText.SetText("Score\n{0:00000}", totalScore);
        if(totalScore > highScore){
            highScore = totalScore;
            hiScoreText.SetText("High Score\n{0:00000}", highScore);
            PlayerPrefs.SetInt(highScoreKey, highScore);
            PlayerPrefs.Save();
        }
    }

    void onPlayerDeath(){
        Debug.Log("Player died :(");
        SceneManager.LoadScene("DemoScene");
    }
}
