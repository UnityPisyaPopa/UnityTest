using UnityEngine;

public class Eye : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float followSpeed;
    [SerializeField] private float cooldown;
    [SerializeField] private float cooldownTime;
    [SerializeField] private Transform laserHit;
    [SerializeField] private int damage;

    private float distance;
    private bool facingRight = true;
    private bool isFlipped = false;
    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.useWorldSpace = true;
    }

    private void FixedUpdate()
    {
        distance = Vector2.Distance(player.transform.position, transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (player.transform.position - transform.position).normalized);

        laserHit.position = hit.point;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, laserHit.position);

        if (hit.collider.CompareTag("Player") && distance < 5f)
        {
            cooldown -= Time.deltaTime;

            if (cooldown <= 0)
            {
                lineRenderer.enabled = true;
                player.GetComponent<Health>().TakeDamage(damage);
                cooldown = cooldownTime;
            }
        }
        else
        {
            lineRenderer.enabled = false;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, followSpeed * Time.deltaTime);           
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
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}