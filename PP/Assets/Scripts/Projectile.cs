using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float velocity;
    public float lifetime;
    public float distance;
    public int damage;

    private void Update()
    {
        if ((transform.position.x >= 100 || transform.position.x <= -100) && (transform.position.y >= 100 || transform.position.y <= -100))
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * velocity * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider != null)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
