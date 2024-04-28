using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Sprite sawedOff;
    [SerializeField] private Sprite sawedOff_reload;

    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform shotPoint;

    [SerializeField] private float reloadStart;
    [SerializeField] private int pelletCount;
    [SerializeField] private float spreadAngle;
    [SerializeField] private int shotsCount;
    private float reload;
    private float spreadAngleStart;
    private float spreadAngleDifference;

    void Update()
    {
        spreadAngleStart = spreadAngle;
        spreadAngleDifference = -spreadAngle / pelletCount * 2;
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        projectile.GetComponent<Transform>().rotation = transform.rotation;


        if (reload <= 0)
        {
            GetComponent<SpriteRenderer>().sprite = sawedOff;
            if (Input.GetMouseButtonDown(0) && shotsCount > 0)
            {
                StartCoroutine(MuzzleFlash());
                for (int i = 0; i < pelletCount; i++)
                {
                    spreadAngle += spreadAngleDifference;
                    GameObject pellet = Instantiate(projectile, shotPoint.position, transform.rotation);
                    pellet.transform.Rotate(Vector3.forward, spreadAngle);
                    pellet.transform.gameObject.tag = "PlayerProjectile";
                }
                spreadAngle = spreadAngleStart;
                shotsCount--;


                if (shotsCount == 0)
                {
                    reload = reloadStart;
                }
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = sawedOff_reload;
            reload -= Time.deltaTime;
            if (reload <= 0)
            {
                shotsCount = 2;
            }
        }
    }

    IEnumerator MuzzleFlash()
    {
        shotPoint.GetComponent<SpriteRenderer>().enabled = true;
        shotPoint.GetComponent<Light2D>().enabled = true;
        yield return new WaitForSeconds(0.08f);
        shotPoint.GetComponent<SpriteRenderer>().enabled = false;
        shotPoint.GetComponent<Light2D>().enabled = false;
    }
}