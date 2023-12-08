using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public float jumpForce = 5f;
    public int hp = 100;

    Vector2 movement;

    private bool facingRight = true;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (!facingRight && mousePosition.x > transform.position.x)
        {
            Flip();
        }
        else if (facingRight && mousePosition.x < transform.position.x)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position +  movement * moveSpeed * Time.fixedDeltaTime);
        
        if(hp <= 0)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Vector3 WeaponScaler = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Transform>().localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        WeaponScaler.x *= -1;
        WeaponScaler.y *= -1;
        GameObject.FindGameObjectWithTag("Weapon").GetComponent<Transform>().localScale = WeaponScaler;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Zombie") 
        {
            hp -= 10;
        }
    }
}
