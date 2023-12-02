using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class z_Health : MonoBehaviour
{
    [Header("Health stats")]
    [SerializeField] private int z_maxHealth = 100;
    private int z_currentHealth;
    public event Action<float> z_HealthChanged;

    private void Start()
    {
        z_currentHealth = z_maxHealth;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))//-хп от тыки
        {
            z_ChangeHealth(-25);
        }
    }
    private void z_ChangeHealth(int value)
    {
        z_currentHealth += value;
        if (z_currentHealth <= 0)
        {
            z_Death();
        }
        else
        {
            float currentHealthAsPercantage = (float)z_currentHealth / z_maxHealth;
            z_HealthChanged?.Invoke(currentHealthAsPercantage);
        }
    }
    private void z_Death()
    { 
        z_HealthChanged?.Invoke(0);
        Debug.Log("LOOOOx Pidr");
    }
}
