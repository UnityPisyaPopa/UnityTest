using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp = 50;
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private int damage;

    [SerializeField] private GameObject player;

    private bool isFlipped = false;
    private bool isTouchingPlayer = false;  
    private bool facingRight = true;
    private bool cooldownEnded = true;

    private void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }   

        if (isTouchingPlayer && cooldownEnded)
        {        
            player.GetComponent<Health>().TakeDamage(damage);
            StartCoroutine(Cooldown());          
        }
    }
    private void FixedUpdate()
    {
        if (isTouchingPlayer == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, followSpeed * Time.deltaTime);
        }
              
        if (player.GetComponent<Transform>().position.x > transform.position.x && isFlipped == false)
        {
            Flip();
            isFlipped = true;
        }
        else if (player.GetComponent<Transform>().position.x < transform.position.x && isFlipped == true)
        {
            Flip();
            isFlipped = false;
        }        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchingPlayer = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchingPlayer = false;
        }
    }

    IEnumerator Cooldown()
    {
        cooldownEnded = false;
        yield return new WaitForSeconds(1);
        cooldownEnded = true;
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}