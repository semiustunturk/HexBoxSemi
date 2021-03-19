using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollw : MonoBehaviour
{
    public Transform target;
    public float speed = 15f;
    public void moving()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, speed * Time.deltaTime);
    }
}
