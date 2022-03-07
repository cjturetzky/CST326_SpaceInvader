using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int totalScore = 0;
    public TextMeshProUGUI hiScoreText;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Enemy e in FindObjectsOfType<Enemy>()){
            e.deathEvent += onEnemyDeath;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onEnemyDeath(int score){
        Debug.Log("Kill confirmed!");
        totalScore += score;
        scoreText.SetText("Score\n{0:00000}", totalScore);
    }
}
