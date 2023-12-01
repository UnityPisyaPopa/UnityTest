using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ZombieController : MonoBehaviour
{
    public GameObject zombie;
    public string playerTag = "Player";
    public float followSpeed = 5f;
    public GameObject player;
    private bool isFlipped = false;

    private bool facingRight = true;

    private Transform playerTransform;

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("1");
        }
    }
    // lox pidro
    public void FixedUpdate()
    {
        if (playerTransform != null)
        {
            Vector3 direction = playerTransform.position - transform.position;
            direction.Normalize();
            transform.position += direction * followSpeed * Time.deltaTime;
            if (player.GetComponent<Transform>().position.x > transform.position.x && isFlipped == false)
            {
                Flip();
                isFlipped = true;
            }
            else if(player.GetComponent<Transform>().position.x < transform.position.x && isFlipped == true)
            {
                Flip();
                isFlipped = false;
            }
        }
       
    }
    
}