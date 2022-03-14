using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public GameObject bullet;
  public Transform shoottingOffset;
  public delegate void DeathDelegate(int score);
  public DeathDelegate deathEvent;
  public const int TOTAL_ENEMIES = 16;
  public float moveTime;
  public float shootCooldown = 2000;
  public static int enemyCount = 16;
  public int enemyType;
  private float timeSinceLastMove = 0;
  private float timeSinceLastShot = 0;

  private bool moveRight = true;
  private int stepCount = 5;
  private Vector3 stepLR;
  private Vector3 stepDown;
  private Animator animator;

    void Start(){
      stepLR = new Vector3(1.25f, 0, 0);
      stepDown = new Vector3(0, -1.25f, 0);
      enemyCount = 16;
      animator = GetComponent<Animator>();
    }

    void Update(){
      moveTime = 2.5f - ((TOTAL_ENEMIES - enemyCount)/4);
      timeSinceLastMove += Time.deltaTime;
      timeSinceLastShot += Time.deltaTime;

      if(timeSinceLastMove >= moveTime){
        moveEnemies();
        timeSinceLastMove = 0;
      }

      if (timeSinceLastShot >= shootCooldown && Random.Range(0, 1000) == 1){
        animator.SetTrigger("Shoot");
        timeSinceLastShot = 0;
        Debug.Log("Incoming!");
        GameObject enemyShot = Instantiate(bullet, shoottingOffset.position, Quaternion.identity);
        enemyShot.GetComponent<Bullet>().speed = -5;
      }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      Die();
    }

    void moveEnemies(){
      Debug.Log("Moving enemies");
      if(stepCount < 10){
        stepCount++;
        transform.position -= stepLR;
      }
      else{
        moveRight = !moveRight;
        transform.position += stepDown;
        stepCount = 0;
        stepLR = -1 * stepLR;
      }

    }

    void Die(){
      Debug.Log("ded");
      animator.SetTrigger("Die");
      enemyCount--;
      if(deathEvent != null){
        Debug.Log("deathEvent delegate triggered!");
        deathEvent((enemyType + 1) * 10);
        if(enemyCount == 0){
          deathEvent(0);
        }
      }
      Destroy(this.transform.gameObject, 0.25f);
    }
}
