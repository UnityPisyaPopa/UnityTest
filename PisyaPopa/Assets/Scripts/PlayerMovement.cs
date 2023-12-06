using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    Vector2 movement;

    private bool facingRight = true;

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
}
