using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
   

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

        if (gameObject == null)
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
        if (collision.gameObject.CompareTag("Health"))
        {
            GetComponent<Health>().health += 50;
            GameObject.FindGameObjectWithTag("HP").GetComponent<Image>().fillAmount += 0.5f;
            Destroy(collision.gameObject);
        }
    }   
}
