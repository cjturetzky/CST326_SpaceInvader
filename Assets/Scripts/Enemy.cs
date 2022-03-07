using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public delegate void DeathDelegate(int score);
  public DeathDelegate deathEvent;
  public float moveTime;
  public float shootCooldown;
  public int enemyType;
  private float timeSinceLastMove = 0;
  private float timeSinceLastShot = 0;

    void Update(){
      timeSinceLastMove += Time.deltaTime;
      timeSinceLastShot += Time.deltaTime;

      if(timeSinceLastMove >= moveTime){
        moveEnemies();
        timeSinceLastMove = 0;
      }

      if (timeSinceLastShot >= shootCooldown && Random.Range(0, 10) == 1)
      {
        timeSinceLastShot = 0;
        Debug.Log("Incoming!");

      }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      Die();
    }

    void moveEnemies(){
      Debug.Log("Moving enemies");
    }

    void Die(){
      Debug.Log("ded");
      if(deathEvent != null){
        Debug.Log("deathEvent delegate triggered!");
        deathEvent((enemyType + 1) * 100);
      }
      Destroy(this.transform.gameObject);
    }
}
