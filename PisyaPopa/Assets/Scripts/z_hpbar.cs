using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class z_hpbar : MonoBehaviour
{
    [SerializeField] private Image healthBarFilling;

    [SerializeField] Health z_health;

    private Camera camera;

    private bool facingRight = true;//
    private bool isFlipped = false;//
    private Transform playerTransform;//
    public GameObject player;//
    public float followSpeed = 0f;//
    public void Flip()//
        
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;// test
    }

    private void z_OnHealthChanged(float valueAsPercantage)
    {
        Debug.Log(valueAsPercantage);
        healthBarFilling.fillAmount = valueAsPercantage;


    }

    private void Awake()
    {
        z_health.HealthChanged += z_OnHealthChanged;
        camera = Camera.main;
    }

    private void OnDestroy()
    {
        z_health.HealthChanged -= z_OnHealthChanged;

    }
    public void FixedUpdate()
    {
        if (playerTransform != null)
        {
            Vector3 direction = playerTransform.position - transform.position;
            direction.Normalize();
            transform.position += direction * followSpeed * Time.deltaTime;
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


    private void LateUpdate()
    {
        transform.LookAt(new Vector3(transform.position.x, camera.transform.position.y, camera.transform.position.z));
        transform.Rotate(0, 180, 0);
    }
}
