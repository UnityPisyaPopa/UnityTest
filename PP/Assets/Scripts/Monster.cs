using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour
{
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;


    [SerializeField] private GameObject player;
    [SerializeField] private float timeToChangeState;
    [SerializeField] private int damage;
    private bool isFlipped = false;
    private bool isTouchingPlayer;
    private bool facingRight = true;
    private SpriteRenderer spriteRender;
    private bool stateCooldownEnded = true;
    private bool attackCooldownEnded = true;
    [SerializeField] private int numberOfStates; 

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
        GetComponent<Health>().health += GetComponent<Health>().maxHealth / 2;
        GetComponent<Health>().maxHealth += GetComponent<Health>().maxHealth / 2;
        followSpeed += followSpeed / 4;

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

        if (isTouchingPlayer && attackCooldownEnded)
        {
            player.GetComponent<Health>().TakeDamage(damage);
            StartCoroutine(AttackCooldown());
        }

        if (player.GetComponent<Transform>() != null)
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

        if (stateCooldownEnded == true && numberOfStates > 0)
        {
            StartCoroutine(ChangeState());
            numberOfStates--;
        }


    }

    private void Update()
    {
        
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

    IEnumerator ChangeState()
    {
        stateCooldownEnded = false;
        yield return new WaitForSeconds(timeToChangeState);
        Change();
        stateCooldownEnded = true;
    }

    IEnumerator AttackCooldown()
    {
        attackCooldownEnded = false;
        yield return new WaitForSeconds(1);
        attackCooldownEnded = true;
    }
}