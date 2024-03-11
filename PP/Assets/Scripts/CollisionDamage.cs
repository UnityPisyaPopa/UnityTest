using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public int collisionDamage = 10;
    [SerializeField] private string collisionTag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(collisionTag) && collisionTag != null)
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.TakeDamage(collisionDamage);
        }    
    }
}
