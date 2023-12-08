using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class HpBarEnemy : MonoBehaviour 
{
    [SerializeField] public Slider slider;
    [SerializeField] public Transform target;
    [SerializeField] public Camera camera;
    [SerializeField] public Vector3 offset;
   



    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }
    
   
    void Update()
    {
        transform.rotation = camera.transform.rotation;
        transform.position = target.position + offset;


    }
    

    
}
