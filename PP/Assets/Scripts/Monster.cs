using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;



public class Monster : MonoBehaviour
{
    public int hp = 70;
    public float followSpeed = 5f;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    private int counter = 0;
    


    public GameObject player;
    private bool isFlipped = false;
    public float stopTime = 1f;
    private bool isTouchingPlayer = false;
    private float stopTimer = 0f;
    private bool facingRight = true;
    private SpriteRenderer spriteRender;

    private void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        if (spriteRender == null)
        {
            spriteRender.sprite = sprite1;
        }
    }
    public void Change()
    {
        if (spriteRender.sprite == sprite1)
        {
            spriteRender.sprite = sprite2;
        }
        else if (spriteRender.sprite == sprite2)
        {
            spriteRender.sprite = sprite3;
        }
    }

    private void Update()
            {
            if (hp <= 0)
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

                if (stopTimer > stopTime)
                {
                    stopTimer = 0f;
                    isTouchingPlayer = false;
                }
            }
            if (player.GetComponent<UnityEngine.Transform>() != null && isTouchingPlayer == false)
            {
                if (player.GetComponent<UnityEngine.Transform>().position.x > transform.position.x && isFlipped == false)
                {
                    Flip();
                    isFlipped = true;
                }
                else if (player.GetComponent<UnityEngine.Transform>().position.x < transform.position.x && isFlipped == true)
                {
                    Flip();
                    isFlipped = false;
                }
            }
        int random = Random.Range(0, 400);

        if (random == 52 && counter != 3)
        {
            GetComponent<Health>().health += 40;
            GetComponent<Health>().maxHealth += 40;
            Change();
            counter  ++;
            followSpeed -= 0.25f;
        }
        


        


        }
        public void Flip()
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
                collision.gameObject.GetComponent<Health>().TakeDamage(25);
            }
        }
    

}