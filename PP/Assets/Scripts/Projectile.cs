using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float velocity;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, whatIsSolid);
        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else if(transform.position.x >= 10000 || transform.position.y >= 100000)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * velocity * Time.deltaTime);
    }
}
