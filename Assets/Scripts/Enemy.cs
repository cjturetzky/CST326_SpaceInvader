using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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
      Debug.Log("Ouch!");
    }

    void moveEnemies(){
      Debug.Log("Moving enemies");
    }
}
