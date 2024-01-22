using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLaser : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private Transform laserHit;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.useWorldSpace = true;

    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.right);
        laserHit.position = hit.point;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, laserHit.position);
        if(Input.GetMouseButton(0))
        {
            lineRenderer.enabled = true;
        }
        else
        {
            lineRenderer.enabled=false;
        }
    }
}
