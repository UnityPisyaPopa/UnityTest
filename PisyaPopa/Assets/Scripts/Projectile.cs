using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float velocity;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    private UnityEngine.Object hit;

    private void Start()
    {
        hit = Resources.Load("hit");
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, whatIsSolid);
        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
                GameObject caboomRef = (GameObject)Instantiate(hit);
                caboomRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * velocity * Time.deltaTime);
    }
}
