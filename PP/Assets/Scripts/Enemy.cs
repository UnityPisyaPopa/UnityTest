using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 50;
    public float followSpeed = 5f;

    public GameObject player;
    private bool isFlipped = false;

    public float stopTime = 1f;
    private bool isTouchingPlayer = false;
    private float stopTimer = 0f;

    private bool facingRight = true;

    private void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }   
    }
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, followSpeed * Time.deltaTime);

        if (isTouchingPlayer)
        {
            stopTimer += Time.deltaTime;

            if(stopTimer > stopTime)
            {
                stopTimer = 0f;
                isTouchingPlayer = false;
            }
        }
        if (player.GetComponent<Transform>() != null && isTouchingPlayer == false)
        {
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

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(25);
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