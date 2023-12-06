using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;
    public string colissionTag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == colissionTag)
        {
            Health health = collision.gameObject.GetComponent<Health>();
            //health.TakeHit(damage);
        }
    }

}
