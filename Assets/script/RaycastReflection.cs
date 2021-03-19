using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RaycastReflection : MonoBehaviour
{
    
    public int reflections;
    public float maxLenght;
    private LineRenderer lineRenderer;
    private Ray ray;
    private RaycastHit hit;
    private Vector3 direction;
    
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag=="Obstacle")
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
    public void working()
    {
        if (Input.GetMouseButton(0))
        {
            ray = new Ray(transform.position, transform.forward);
            lineRenderer.positionCount = 1;
            lineRenderer.SetPosition(0, transform.position);

            float remainningLenght = maxLenght;
            for (int i = 0; i < reflections; i++)
            {
                if (Physics.Raycast(ray.origin, ray.direction, out hit, remainningLenght))
                {
                    lineRenderer.positionCount += 1;
                    lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);
                    remainningLenght -= Vector3.Distance(ray.origin, hit.point);
                    ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                    if (hit.collider.tag != "Mirror")
                        break;
                }
                else
                {
                    lineRenderer.positionCount += 1;
                    lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction * remainningLenght);
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            lineRenderer.enabled =false;
        }
    }
}
