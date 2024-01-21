using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Eye : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float followSpeed;
    [SerializeField] private float cooldown;
    [SerializeField] private float cooldownTime;

    private float distance;
    private bool facingRight = true;
    private bool isFlipped = false;

    private void Update()
    {
        cooldown -= Time.deltaTime;
        distance = Vector2.Distance(player.transform.position, transform.position);
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (player.transform.position - transform.position).normalized);

        Debug.DrawRay(transform.position, (player.transform.position - transform.position).normalized * 5f, Color.red);

        if (hit.collider.CompareTag("Player") && distance < 5f)
        {
            if (cooldown <= 0)
            {
                player.GetComponent<Player>().hp -= 20;
                Debug.Log("Player hit");
                cooldown = cooldownTime;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, followSpeed * Time.deltaTime);
        }

        if (player.GetComponent<UnityEngine.Transform>() != null)
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
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}


