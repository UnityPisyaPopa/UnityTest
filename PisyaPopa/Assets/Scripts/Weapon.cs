using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Camera cam;
    public GameObject projectile;
    public Transform shotPoint;
    private float reload;
    public float reloadStart;

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (reload <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                reload = reloadStart;
            }
        }
        else
        {
            reload -= Time.deltaTime;
        }
    }
}
