using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    [SerializeField] private Image bar;

    private void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        

        if (health <= 0 && gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if(health <= 0)
        {
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("HP").GetComponent<Image>().fillAmount -= damage / 100f;
        }
    }
}
