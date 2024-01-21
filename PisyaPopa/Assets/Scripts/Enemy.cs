using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] HpBarEnemy healthBar;
    public int maxHealth = 50;
    public int hp = 50;
    public float followSpeed = 5f;

    public GameObject player;
    private bool isFlipped = false;

    public float stopTime = 1f;
    private bool isTouchingPlayer = false;
    private float stopTimer = 0f;

    private bool facingRight = true;

<<<<<<< HEAD
=======
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

>>>>>>> 2b82b48a2ce040a702790fe5b861c65ff93d9662
    private void Update()
    {
        if(hp <= 0 && isEnemyLive == true)
        {
<<<<<<< HEAD
            Destroy(gameObject);
        }   
=======
            killEnemy();
        }
>>>>>>> 2b82b48a2ce040a702790fe5b861c65ff93d9662
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
<<<<<<< HEAD
            if (player.GetComponent<Transform>().position.x > transform.position.x && isFlipped == false)
=======
            Vector3 direction = playerTransform.position - transform.position;
            direction.Normalize();
            transform.position += direction * followSpeed * Time.deltaTime;
            if (player.GetComponent<Transform>().position.x > transform.position.x && isFlipped == false )
>>>>>>> 2b82b48a2ce040a702790fe5b861c65ff93d9662
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
        }
    }
    public void Flip()
    {
       
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
       
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}