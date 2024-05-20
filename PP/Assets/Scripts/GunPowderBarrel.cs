using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GunPowderBarrel : MonoBehaviour
{
    [SerializeField] private int damage;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            StartCoroutine(MuzzleFlash());
        }        
    }
    IEnumerator MuzzleFlash()
    {
        gameObject.GetComponent<Light2D>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<Light2D>().enabled = false;
        Destroy(gameObject);
    }
}
