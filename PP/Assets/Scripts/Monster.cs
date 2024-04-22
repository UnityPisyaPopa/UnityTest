using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;


    [SerializeField] private GameObject player;
    private bool isFlipped = false;
    //[SerializeField] private float stopTime = 1f;
    private bool isTouchingPlayer;
    //private float stopTimer = 0f;
    private bool facingRight = true;
    private SpriteRenderer spriteRender;
    private int counter = 0;

    private void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        if (spriteRender == null)
        {
            spriteRender.sprite = sprite1;
        }
    }
    private void Change()
    {
        if (spriteRender.sprite == sprite1)
        {
            spriteRender.sprite = sprite2;
        }
        else 
        {
            spriteRender.sprite = sprite1;
        }
    }

    private void FixedUpdate()
    {
        if (isTouchingPlayer == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, followSpeed * Time.deltaTime);
        }

        /*if (isTouchingPlayer)
        {
            stopTimer += Time.deltaTime;

            if (stopTimer > stopTime)
            {
                stopTimer = 0f;
            }
        }*/
        //if (player.GetComponent<Transform>() != null /*&& isTouchingPlayer == false*/)
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
        int random = Random.Range(0, 300);

        if (random == 52 && counter !=2)
        {
            GetComponent<Health>().health += GetComponent<Health>().health / 2;
            GetComponent<Health>().maxHealth += GetComponent<Health>().maxHealth / 2;
            followSpeed += followSpeed / 4;
            Change();
            counter++;
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(25);
            isTouchingPlayer = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isTouchingPlayer = false;
        }
    }
}