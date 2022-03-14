using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;
  public float moveSpeed = 3.0f;
  public Transform shottingOffset;
  public delegate void PlayerDeathDelegate();
  public PlayerDeathDelegate playerDeathEvent;
  private Animator playerAnimator;
    // Update is called once per frame

    void Start(){
      playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");
        playerAnimator.SetTrigger("Shoot");
        Destroy(shot, 3f);

      }

      if (Input.GetKey("left")){
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
      }

      if (Input.GetKey("right")){
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
      }
    }

    void OnCollisionEnter2D(Collision2D collision){
      Debug.Log("Player died");
      playerAnimator.SetTrigger("Die");
      Die();
      Destroy(this.transform.gameObject, 2f);
    }

    void Die(){
      if(playerDeathEvent != null){
        Debug.Log("playerDeathEvent delegate invoked");
        playerDeathEvent();
      }
    }
}
