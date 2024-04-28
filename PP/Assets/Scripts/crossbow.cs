using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crossbow : MonoBehaviour
{
    [SerializeField] private Sprite crossbow_sprite;
    [SerializeField] private GameObject arrow_projectile;
    [SerializeField] private float reloadStart;
    [SerializeField] private Transform shotPoint;
    private float reload;


    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        if (reload > 0)
        {
            reload -= Time.deltaTime;
        }
               
        if (Input.GetMouseButtonDown(0) && reload <= 0)
        {                  
            GameObject arrow = Instantiate(arrow_projectile, shotPoint.position, transform.rotation);
            arrow.transform.Rotate(Vector3.forward);
            arrow.transform.gameObject.tag = "PlayerProjectile";
            reload = reloadStart;
        }
    }
}
