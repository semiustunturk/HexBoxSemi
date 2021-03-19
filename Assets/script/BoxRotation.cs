using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRotation : MonoBehaviour
{
    [SerializeField] private float yPlus = 20;
    float yRot;
    void OnMouseDown()
    {  
        yRot += yPlus;
        transform.rotation = Quaternion.Euler(0, yRot, 0);
    }
}
