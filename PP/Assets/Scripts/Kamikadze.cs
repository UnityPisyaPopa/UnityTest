using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Kamikadze : MonoBehaviour
{
    [SerializeField] private float followSpeed;
    [SerializeField] private int damage;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject GunpowderBarrelPrefab;

    private bool isFlipped = false;
    private bool isTouchingPlayer = false;
    private bool facingRight = true;
    private bool isFiringTheBomb = false;

    private void OnDestroy()
    {
        if (isFiringTheBomb == false)
        {
            _ = Instantiate(GunpowderBarrelPrefab, transform.position, transform.rotation);
        }
    }
    private void Update()
    {
        if (isTouchingPlayer == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, followSpeed * Time.deltaTime);
        }
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
 
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Health>().TakeDamage(damage);
            StartCoroutine(MuzzleFlash());
        }
    }
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    IEnumerator MuzzleFlash()
    {
        isFiringTheBomb = true;
        gameObject.GetComponent<Light2D>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<Light2D>().enabled = false;       
        Destroy(gameObject);
    }

}
