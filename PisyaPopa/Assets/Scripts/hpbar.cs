using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class hpbar : MonoBehaviour
{
    [SerializeField] private Image healthBarFilling;

    [SerializeField] Health health;

    private Camera camera;
    private bool facingRight = true; // test
    private Vector2 moveInput;//test
    private void Flip()//
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale; // test
        Scaler.x *= -1;
        transform.localScale = Scaler;//
    }

    private void OnHealthChanged(float valueAsPercantage)
    {
        Debug.Log(valueAsPercantage);
        healthBarFilling.fillAmount = valueAsPercantage;


    }

    private void Awake()
    {
        health.HealthChanged += OnHealthChanged;
        camera = Camera.main;
    }

    private void OnDestroy()
    {
        health.HealthChanged -= OnHealthChanged;

    }
    private void Update()//
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); // test

        if (!facingRight && moveInput.x > 0)
        {
            Flip();
        }
        else if (facingRight && moveInput.x < 0)
        {
            Flip();//
        }
    }


    private void LateUpdate()
    {
        transform.LookAt(new Vector3(transform.position.x, camera.transform.position.y, camera.transform.position.z));
        transform.Rotate(0, 180, 0);
    }
}
