﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;
  public float moveSpeed = 3.0f;
  public Transform shottingOffset;
    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");

        Destroy(shot, 3f);

      }

      if (Input.GetKey("left")){
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
      }

      if (Input.GetKey("right")){
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
      }
    }
}
