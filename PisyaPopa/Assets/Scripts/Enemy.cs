using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] HpBarEnemy healthBar;
    public int maxHealth = 50;
    public int hp = 50;
    public GameObject zombie;
    public string playerTag = "Player";
    public float followSpeed = 5f;

    public GameObject player;
    private bool isFlipped = false;

    public float stopTime = 1f;
    private bool isTouchingPlayer = false;
    private float stopTimer = 0f;

    public float jumpForce = 5f;
    private Rigidbody2D rb;

    private bool facingRight = true;

    private Transform playerTransform;

    private UnityEngine.Object caboom;
    private bool isEnemyLive = true;


    private void Awake()
    {
        healthBar = GetComponentInChildren<HpBarEnemy>();
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthBar.UpdateHealthBar(hp, maxHealth);
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);

        caboom = Resources.Load("caboom");

        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            
        }
    }

    private void Update()
    {
        if(hp <= 0 && isEnemyLive == true)
        {
            killEnemy();
        }
    }

    private void killEnemy()
    {
        GameObject caboomRef = (GameObject)Instantiate(caboom);
        caboomRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Destroy(gameObject);
        isEnemyLive = false;
    }

    private void FixedUpdate()
    {

        if(isTouchingPlayer)
        {
            stopTimer += Time.deltaTime;

            if(stopTimer> stopTime)
            {
                stopTimer = 0f;
                isTouchingPlayer = false;
                }
            }




        if (playerTransform != null && isTouchingPlayer == false)
        {
            Vector3 direction = playerTransform.position - transform.position;
            direction.Normalize();
            transform.position += direction * followSpeed * Time.deltaTime;
            if (player.GetComponent<Transform>().position.x > transform.position.x && isFlipped == false )
            {
                Flip();
                isFlipped = true;
            }
            else if (player.GetComponent<Transform>().position.x < transform.position.x && isFlipped == true )
            {
                Flip();
                isFlipped = false;
            }
        }

    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        healthBar.UpdateHealthBar(hp, maxHealth);
        
            
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchingPlayer = true;
            // rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    public void Flip()
    {
       
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
       
    }

}